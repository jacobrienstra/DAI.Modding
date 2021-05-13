using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.ModMaker.Utilities;

namespace DAI.ModMaker
{
	public partial class SearchWindow : Window, IComponentConnector
	{
		private int LastFoundIndex;

		private string LastSearchString;

		private string LastDirectoryString;

		private AssetFolder SelectedFolder;


		public SearchWindow(AssetFolder InSelectedFolder)
		{
			InitializeComponent();
			LastFoundIndex = -1;
			LastSearchString = "";
			SelectedFolder = InSelectedFolder;
			EbxPathTextBox.Text = ((InSelectedFolder != null && InSelectedFolder.Path != null) ? InSelectedFolder.Path.ToLower().Remove(0, 5) : "");
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			SearchButton.IsEnabled = false;
			if (LastSearchString != SearchTextBox.Text)
			{
				LastFoundIndex = -1;
			}
			if (LastDirectoryString != EbxPathTextBox.Text)
			{
				LastFoundIndex = -1;
			}
			LastSearchString = SearchTextBox.Text;
			LastDirectoryString = EbxPathTextBox.Text;
			List<EbxRef> allEbx = Library.GetAllEbx();
			if (EbxPathTextBox.Text != "")
			{
				allEbx = allEbx.Where((EbxRef x) => x.Name.ToLower().Contains(EbxPathTextBox.Text.ToLower())).ToList();
			}
			allEbx.Sort((EbxRef A, EbxRef B) => A.Name.CompareTo(B.Name));
			List<EbxRef> ebxAssets1 = ((LastFoundIndex > -1) ? allEbx.GetRange(LastFoundIndex + 1, allEbx.Count - (LastFoundIndex + 1)) : allEbx);
			int num = 0;
			new Thread((ThreadStart)delegate
			{
				List<EbxRef> ebxAssets2 = new List<EbxRef>();
				num = ebxAssets1.FindIndex(delegate (EbxRef A)
				{
					SearchWindow searchWindow = this;
					SearchResultsListBox.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate
					{
						searchWindow.SearchStatusText.Text = A.Name;
						return null;
					}, null);
					return EbxBase.FromEbx(A).ToXml(false).ToLower()
						.Contains(LastSearchString.ToLower());
				});
				SearchResultsListBox.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate
				{
					if (num != -1)
					{
						ebxAssets2.Add(ebxAssets1[num]);
					}
					List<EbxRefWrapper> list = new List<EbxRefWrapper>();
					foreach (EbxRef current in ebxAssets2)
					{
						list.Add(new EbxRefWrapper(current));
					}
					SearchResultsListBox.ItemsSource = list;
					SearchButton.IsEnabled = true;
					SearchStatusText.Text = "";
					return null;
				}, null);
				LastFoundIndex = ((num != -1) ? (LastFoundIndex + num + 1) : (-1));
			}).Start();
		}

		private void SearchResultsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			EbxRefWrapper selectedItem = SearchResultsListBox.SelectedItem as EbxRefWrapper;
			if (selectedItem != null)
			{
				new EbxPreviewWindow(EbxBase.FromEbx(selectedItem.Ebx)).Show();
			}
		}

		private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		public void SetSearchFolder(AssetFolder InSelectedFolder)
		{
			SelectedFolder = InSelectedFolder;
			EbxPathTextBox.Text = ((InSelectedFolder == null || !(InSelectedFolder.Name != "Data")) ? "" : InSelectedFolder.Path.ToLower().Remove(0, 5));
		}
	}
}
