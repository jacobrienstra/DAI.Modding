using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

using DAI.AssetLibrary.Assets.References;
using DAI.ModMaker.Utilities;

namespace DAI.ModMaker.Controls
{
	public partial class AssetPicker : UserControl, IComponentConnector
	{
		private EbxRef IntAssignedAsset;

		public EbxRef AssignedAsset
		{
			get
			{
				return IntAssignedAsset;
			}
			set
			{
				IntAssignedAsset = value;
				AssetNameText.Text = ((value != null) ? value.GetDisplayFullName() : "No Selection");
			}
		}

		public AssetPicker()
		{
			InitializeComponent();
		}

		private void AssignButton_Click(object sender, RoutedEventArgs e)
		{
			IntAssignedAsset = Globals.SelectedAsset;
			AssetNameText.Text = IntAssignedAsset.GetDisplayFullName();
		}
	}
}
