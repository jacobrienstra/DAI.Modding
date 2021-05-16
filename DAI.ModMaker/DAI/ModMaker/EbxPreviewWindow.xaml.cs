using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.ModMaker.DAIModules;
using DAI.ModMaker.Properties;
using DAI.ModMaker.Utilities;

using Microsoft.Win32;

namespace DAI.ModMaker
{
    public partial class EbxPreviewWindow : Window, IComponentConnector
    {
        private EbxBase Ebx;

        private bool InEditMode;

        private bool _Initialized;

        public EbxPreviewWindow(EbxBase InEbx)
        {
            InitializeComponent();
            Ebx = InEbx;
            chkOffsets.IsChecked = Settings.Default.EbxShowOffsets;
            chkGuidAsInvertedStrings.IsChecked = Settings.Default.EbxInvertGuid;
            BuildEbxDocument();
            EbxRef ebxByGuid = Library.GetEbxByGuid(Ebx.FileGuid);
            if (DAIModuleManager.HasImporter(ebxByGuid.AssetType))
            {
                ImportAssetMenuItem.IsEnabled = true;
            }
            if (DAIModuleManager.HasExporter(ebxByGuid.AssetType))
            {
                ExportAssetMenuItem.IsEnabled = true;
            }
            if (DAIModuleManager.HasPreviewer(ebxByGuid.AssetType))
            {
                PreviewAssetMenuItem.IsEnabled = true;
            }
            _Initialized = true;
        }

        private void DebugExportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Export EBX",
                Filter = "*.ebx|*.ebx"
            };
            if (!saveFileDialog.ShowDialog().Value)
            {
                return;
            }
            byte[] payload = PayloadProvider.GetAssetPayload(Library.GetEbxByGuid(Ebx.FileGuid));
            using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(payload);
                }
            }
            MessageBox.Show("Exported to " + saveFileDialog.FileName);
        }

        private void DebugImportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Import EBX",
                Filter = "*.ebx|*.ebx"
            };
            if (!openFileDialog.ShowDialog().Value)
            {
                return;
            }
            EbxRef ebx = Library.GetEbxByGuid(Ebx.FileGuid);
            using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    byte[] numArray = new byte[binaryReader.BaseStream.Length];
                    numArray = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
                    LibraryManager.ModifyEbx(ebx, numArray, false);
                    using (MemoryStream ms = new MemoryStream(numArray))
                    {
                        Ebx = EbxBase.ReadFromStream(ms);
                    }
                }
            }
            AssetDocument.Blocks.Clear();
            Ebx.ToDocument(new YamlFlowDocumentWriter(AssetDocument));
            MessageBox.Show("Successfully imported EBX from " + openFileDialog.FileName);
        }

        private void ExportAssetMenuItem_Click(object sender, RoutedEventArgs e)
        {
            EbxRef ebx = Library.GetEbxByGuid(Ebx.FileGuid);
            DAIBaseExporter exporter = DAIModuleManager.GetExporter(ebx.AssetType);
            string str = "";
            string[] extensions = exporter.GetExtensions();
            foreach (string str2 in extensions)
            {
                string str3 = str;
                str = str3 + "*." + str2 + "|*." + str2 + "|";
            }
            str = str.TrimEnd('|');
            string filename = ebx.Name;
            if (filename.EndsWith("/"))
            {
                string text = filename;
                filename = text.Remove(text.Length - 1);
            }
            if (filename.Contains("/"))
            {
                string text2 = filename;
                filename = text2.Substring(text2.LastIndexOf("/") + 1);
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Choose Resource",
                Filter = str,
                FileName = filename
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                string str4 = "";
                if (exporter.Run(Ebx.GetContainer(), saveFileDialog.FileName, out str4))
                {
                    MessageBox.Show("Resource successfully exported to " + saveFileDialog.FileName);
                }
                else if (str4 != "")
                {
                    MessageBox.Show("Resource failed to export: " + str4);
                }
            }
        }

        private void ImportAssetMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DAIBaseImporter importer = DAIModuleManager.GetImporter(Library.GetEbxByGuid(Ebx.FileGuid).AssetType);
            string str = "";
            string[] extensions = importer.GetExtensions();
            foreach (string str2 in extensions)
            {
                string str3 = str;
                str = str3 + "*." + str2 + "|*." + str2 + "|";
            }
            str = str.TrimEnd('|');
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Choose Resource",
                Filter = str
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string str4 = "";
                if (importer.Run(Ebx.GetContainer(), openFileDialog.FileName, out str4))
                {
                    MessageBox.Show("Resource successfully imported from " + openFileDialog.FileName);
                }
                else if (str4 != "")
                {
                    MessageBox.Show("Resource failed to import: " + str4);
                }
            }
        }

        private void PreviewAssetMenuItem_Click(object sender, RoutedEventArgs e)
        {
            EbxRef ebx = Library.GetEbxByGuid(Ebx.FileGuid);
            DAIModuleManager.GetPreviewer(ebx.AssetType).Run(Ebx.GetContainer(), ebx);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            EbxRef ebx = Library.GetEbxByGuid(Ebx.FileGuid);
            LibraryManager.ModifyEbx(ebx, Ebx.WriteToStream().ToArray(), false);
            EditButton.Visibility = Visibility.Visible;
            SaveButton.Visibility = Visibility.Collapsed;
            MessageBox.Show("Successfully updated " + ebx.Name);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = sender as Hyperlink;
            if (link != null)
            {
                ExternalGuid guid = link.Tag as ExternalGuid;
                if (guid != null)
                {
                    new EbxPreviewWindow(EbxBase.FromEbx(Library.GetEbxByGuid(guid.FileGuid))).Show();
                }
            }
        }

        private static IEnumerable<DependencyObject> GetVisuals(DependencyObject root)
        {
            foreach (DependencyObject child in LogicalTreeHelper.GetChildren(root).OfType<DependencyObject>())
            {
                yield return child;
                foreach (DependencyObject visual in GetVisuals(child))
                {
                    yield return visual;
                }
            }
        }

        private void BuildEbxDocument()
        {
            AssetDocument.Blocks.Clear();
            YamlFlowDocumentWriter writer = new YamlFlowDocumentWriter(AssetDocument);
            writer.EditMode = InEditMode;
            Ebx.ToDocument(writer, chkOffsets.IsChecked.GetValueOrDefault(), chkGuidAsInvertedStrings.IsChecked.GetValueOrDefault());
            foreach (Hyperlink item in GetVisuals(AssetDocument).OfType<Hyperlink>())
            {
                item.Click += Hyperlink_Click;
            }
        }

        private void chkShowOffsets_Checked(object sender, RoutedEventArgs e)
        {
            bool isChecked = chkOffsets.IsChecked.HasValue && chkOffsets.IsChecked.Value;
            Settings.Default.EbxShowOffsets = isChecked;
            Settings.Default.Save();
            if (_Initialized)
            {
                BuildEbxDocument();
            }
        }

        private void chkGuidAsInvertedString_Checked(object sender, RoutedEventArgs e)
        {
            bool isChecked = chkGuidAsInvertedStrings.IsChecked.HasValue && chkGuidAsInvertedStrings.IsChecked.Value;
            Settings.Default.EbxInvertGuid = isChecked;
            Settings.Default.Save();
            if (_Initialized)
            {
                BuildEbxDocument();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            InEditMode = true;
            EditButton.Visibility = Visibility.Collapsed;
            SaveButton.Visibility = Visibility.Visible;
            BuildEbxDocument();
        }
    }
}
