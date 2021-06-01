using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;

using Microsoft.Win32;

namespace DAI.ModMaker {
    public partial class ResourceListPreview : Window, IComponentConnector {
        public ResourceListPreview() {
            InitializeComponent();
            FilterComboBox.Items.Add("Select Filter...");
            string[] names = Enum.GetNames(typeof(ResType));
            foreach (string list in names) {
                FilterComboBox.Items.Add(list);
            }
            FilterComboBox.SelectedIndex = 0;
            List<ResRef> allRes = Library.GetAllRes();
            ResourceListBox.ItemsSource = allRes;
        }

        private void ExtractButton_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog {
                Filter = "*.bin|*.bin",
                Title = "Extract Resource"
            };
            if (saveFileDialog.ShowDialog() != true) {
                return;
            }
            byte[] assetPayload = PayloadProvider.GetAssetPayload((ResRef)ResourceListBox.SelectedItem);
            using (MemoryStream ms = new MemoryStream(assetPayload)) {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create)) {
                    using (BinaryWriter binaryWriter = new BinaryWriter(fs)) {
                        byte[] numArray = new byte[assetPayload.Length];
                        ms.Read(numArray, 0, assetPayload.Length);
                        binaryWriter.Write(numArray);
                    }
                }
            }
            MessageBox.Show("Resource extracted to " + saveFileDialog.FileName);
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (FilterComboBox.SelectedIndex < 0) {
                return;
            }
            if (FilterComboBox.SelectedIndex == 0) {
                List<ResRef> allRes = Library.GetAllRes();
                ResourceListBox.ItemsSource = allRes;
                return;
            }
            ResType selectedItem = (ResType)Enum.Parse(typeof(ResType), (string)FilterComboBox.SelectedItem);
            List<ResRef> resAssets = (from A in Library.GetAllRes()
                                      where A.ResType == (int)selectedItem
                                      select A).ToList();
            resAssets.Sort((ResRef A, ResRef B) => A.Name.CompareTo(B.Name));
            ResourceListBox.ItemsSource = resAssets;
        }

        private void RefreshData() {
            if (ResourceListBox.SelectedItem != null) {
                ResRef selectedItem = (ResRef)ResourceListBox.SelectedItem;
                ResourceNameText.Text = selectedItem.Name;
                byte[] assetPayload = PayloadProvider.GetAssetPayload(selectedItem);
                ResourceHexControl.SetByteData(assetPayload);
                ResourceHexControl.ParentResAsset = selectedItem;
            }
        }

        private void ReplaceButton_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "*.bin|*.bin"
            };
            if (openFileDialog.ShowDialog() == true) {
                byte[] numArray = null;
                using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read)) {
                    numArray = new byte[fileStream.Length];
                    fileStream.Read(numArray, 0, numArray.Length);
                }
                LibraryManager.ModifyRes((ResRef)ResourceListBox.SelectedItem, numArray, false);
                MessageBox.Show("Resource successfully replaced!");
                RefreshData();
            }
        }

        private void ResourceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            RefreshData();
            ExtractButton.IsEnabled = ResourceListBox.SelectedItem != null;
            ReplaceButton.IsEnabled = ResourceListBox.SelectedItem != null;
        }
    }
}
