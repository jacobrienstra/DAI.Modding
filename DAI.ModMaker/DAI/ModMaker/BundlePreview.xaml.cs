using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;

namespace DAI.ModMaker
{
    public partial class BundlePreview : Window, IComponentConnector
	{

		public BundlePreview()
		{
			InitializeComponent();
		}

		private void AssetsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (AssetsListBox.SelectedIndex != -1)
			{
				EbxRef selectedItem = AssetsListBox.SelectedItem as EbxRef;
				if (selectedItem != null)
				{
					new EbxPreviewWindow(EbxBase.FromEbx(selectedItem)).Show();
				}
			}
		}

		private void BundleFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (BundlesListBox != null)
			{
				DisplaySuperBundles();
			}
		}

		private void BundlesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (BundlesListBox.SelectedIndex == -1)
			{
				AssetsListBox.Items.Clear();
				ResourcesListBox.Items.Clear();
				ChunksListBox.Items.Clear();
			}
			else
			{
				RefreshData();
			}
		}

		private void FilterButton_Click(object sender, RoutedEventArgs e)
		{
			DisplaySuperBundles();
		}

		private void RefreshData()
		{
			SubBundleRef selectedItem = BundlesListBox.SelectedItem as SubBundleRef;
			if (selectedItem == null)
			{
				return;
			}
			SubBundleRef sb = Library.GetAllSubBundles().Find((SubBundleRef A) => A.Path == selectedItem.Path);
			AssetsListBox.Items.Clear();
			ResourcesListBox.Items.Clear();
			ChunksListBox.Items.Clear();
			bool? isChecked = ShowModifiedCheckBox.IsChecked;
			List<EbxRef> ebxAssets = new List<EbxRef>(sb.GetSbEbx());
			if (isChecked.HasValue && isChecked.Value)
			{
				ebxAssets = ebxAssets.Where((EbxRef x) => x.State != EntryState.NoChanges).ToList();
			}
			ebxAssets.Sort((EbxRef A, EbxRef B) => A.AssetType.CompareTo(B.AssetType) + A.Name.CompareTo(B.Name));
			for (int i = 0; i < ebxAssets.Count; i++)
			{
				AssetsListBox.Items.Add(ebxAssets[i]);
			}
			List<ResRef> resAssets = new List<ResRef>(sb.GetSbRes());
			if (isChecked.HasValue && isChecked.Value)
			{
				resAssets = resAssets.Where((ResRef x) => x.State != EntryState.NoChanges).ToList();
			}
			for (int j = 0; j < resAssets.Count; j++)
			{
				ResourcesListBox.Items.Add(resAssets[j]);
			}
			List<ChunkRef> chunkAssets = new List<ChunkRef>(sb.GetSbChunks());
			if (isChecked.HasValue && isChecked.Value)
			{
				chunkAssets = chunkAssets.Where((ChunkRef x) => x.State != EntryState.NoChanges).ToList();
			}
			for (int k = 0; k < chunkAssets.Count; k++)
			{
				ChunksListBox.Items.Add(chunkAssets[k]);
			}
		}

		private void ShowModifiedCheckBox_Click(object sender, RoutedEventArgs e)
		{
			RefreshData();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			DisplaySuperBundles();
		}

		private void DisplaySuperBundles()
		{
			BundlesListBox.Items.Clear();
			List<SubBundleRef> allBundles = (from A in Library.GetAllSubBundles()
											 where A.Path.ToLower().Contains(FilterTextBox.Text.ToLower())
											 select A).ToList();
			if (BundleFilterComboBox.SelectedIndex == 1)
			{
				allBundles = allBundles.Where((SubBundleRef x) => x.State != EntryState.NoChanges).ToList();
			}
			allBundles.Sort((SubBundleRef A, SubBundleRef B) => A.Path.CompareTo(B.Path));
			for (int i = 0; i < allBundles.Count; i++)
			{
				BundlesListBox.Items.Add(allBundles[i]);
			}
		}
	}
}
