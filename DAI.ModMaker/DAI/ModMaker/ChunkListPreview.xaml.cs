using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;

using Microsoft.Win32;

using AssetLibUtilUtil = DAI.AssetLibrary.Utilities.Utilities;

namespace DAI.ModMaker
{
    public partial class ChunkListPreview : Window, IComponentConnector
    {
        private ResRef ParentAsset;

        public ChunkListPreview(ResRef InResAsset, List<ChunkRef> InChunkAssets)
        {
            InitializeComponent();
            ChunkHexControl.MenuBarHidden = true;
            foreach (ChunkRef inChunkAsset in InChunkAssets)
            {
                ChunksListBox.Items.Add(inChunkAsset);
            }
            ParentAsset = InResAsset;
        }

        private void ChunksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
            ExtractButton.IsEnabled = ChunksListBox.SelectedItem != null;
            ReplaceButton.IsEnabled = ChunksListBox.SelectedItem != null;
        }

        private void ExtractButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save CHUNK resource",
                Filter = "*.bin|*.bin"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                BinaryWriter binaryWriter = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.Create));
                binaryWriter.Write(ChunkHexControl.GetByteData());
                binaryWriter.Close();
                MessageBox.Show("CHUNK saved to " + saveFileDialog.FileName);
            }
        }

        private void RefreshData()
        {
            if (ChunksListBox.SelectedItem != null)
            {
                ChunkRef selectedItem = (ChunkRef)ChunksListBox.SelectedItem;
                ChunkNameText.Text = selectedItem.ChunkId.ToString();
                byte[] assetPayload = PayloadProvider.GetAssetPayload(selectedItem);
                ChunkHexControl.SetByteData(assetPayload);
            }
        }

        private void ReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Choose CHUNK resource",
                Filter = "*.bin|*.bin"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                byte[] numArray = new byte[fileStream.Length];
                fileStream.Read(numArray, 0, (int)fileStream.Length);
                fileStream.Close();
                Guid dQWord = Guid.Empty;
                ChunkRef selectedItem = (ChunkRef)ChunksListBox.SelectedItem;
                ChunkRef chunkAsset = new ChunkRef
                {
                    Sha1 = "00000000000000000000",
                    ChunkId = dQWord
                };
                LibraryManager.AddChunk(chunkAsset, numArray, true);
                chunkAsset.H32 = selectedItem.H32;
                chunkAsset.Meta = new byte[1];
                ImportCompressData importCompressDatum = new ImportCompressData();
                AssetLibUtilUtil.CompressData(numArray, ref importCompressDatum);
                chunkAsset.RangeStart = 0;
                chunkAsset.RangeEnd = importCompressDatum.RangeEnd;
                chunkAsset.LogicalOffset = numArray.Length & -16777216;
                chunkAsset.LogicalSize = numArray.Length & 0xFFFFFF;
                LibraryManager.AddToBundles(chunkAsset, ParentAsset.ParentSbs);
                LibraryManager.DeleteChunk(chunkAsset);
                int selectedIndex = ChunksListBox.SelectedIndex;
                ChunksListBox.Items.RemoveAt(selectedIndex);
                ChunksListBox.Items.Insert(selectedIndex, chunkAsset);
                ChunksListBox.SelectedIndex = selectedIndex;
                MessageBox.Show("Chunk replaced with " + openFileDialog.FileName);
            }
        }
    }
}
