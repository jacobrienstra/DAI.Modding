using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Markup;

using Be.Windows.Forms;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.ModMaker.Controls
{
    public partial class HexEditor : UserControl, IComponentConnector
    {
        private HexBox ResourceHexControl;

        public ResRef ParentResAsset;

        public bool MenuBarHidden
        {
            get
            {
                return MenuBarGrid.Visibility == Visibility.Collapsed;
            }
            set
            {
                MenuBarGrid.Visibility = (value ? Visibility.Collapsed : Visibility.Visible);
                RootGrid.RowDefinitions[0].Height = (value ? new GridLength(0.0) : new GridLength(20.0));
            }
        }

        public HexEditor()
        {
            InitializeComponent();
            WindowsFormsHost windowsFormsHost = new WindowsFormsHost();
            ResourceHexControl = new HexBox
            {
                VScrollBarVisible = true,
                StringViewVisible = true,
                UseFixedBytesPerLine = true,
                Font = new Font("Consolas", 9f)
            };
            windowsFormsHost.Child = ResourceHexControl;
            HexContainer.Children.Add(windowsFormsHost);
        }

        public void ClearByteData()
        {
            ResourceHexControl.ByteProvider = null;
        }

        private void FindChunksMenuItem_Click(object sender, RoutedEventArgs e)
        {
            List<ChunkRef> chunkAssets = new List<ChunkRef>();
            MemoryStream memoryStream = new MemoryStream();
            if (ResourceHexControl.ByteProvider != null)
            {
                for (int i = 0; i < ResourceHexControl.ByteProvider.Length; i++)
                {
                    memoryStream.WriteByte(ResourceHexControl.ByteProvider.ReadByte(i));
                }
            }
            memoryStream.Position = 0L;
            _ = Guid.Empty;
            BinaryReader binaryReader = new BinaryReader(memoryStream);
            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
            {
                Guid guidFromDoubleULong = GuidExt.GetGuidFromDoubleULong(binaryReader.ReadUInt64(), binaryReader.ReadUInt64());
                binaryReader.BaseStream.Position -= 15L;
                ChunkRef chunk = Library.GetChunkById(guidFromDoubleULong);
                if (chunk != null)
                {
                    chunkAssets.Add(chunk);
                }
                if (binaryReader.BaseStream.Position + 16 >= binaryReader.BaseStream.Length)
                {
                    break;
                }
            }
            if (chunkAssets.Count == 0)
            {
                MessageBox.Show("Resource contains no chunks.");
            }
            else
            {
                new ChunkListPreview(ParentResAsset, chunkAssets).Show();
            }
        }

        public byte[] GetByteData()
        {
            byte[] numArray = new byte[ResourceHexControl.ByteProvider.Length];
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = ResourceHexControl.ByteProvider.ReadByte(i);
            }
            return numArray;
        }

        public void SetByteData(byte[] InData)
        {
            ResourceHexControl.ByteProvider = new DynamicByteProvider(InData);
        }
    }
}
