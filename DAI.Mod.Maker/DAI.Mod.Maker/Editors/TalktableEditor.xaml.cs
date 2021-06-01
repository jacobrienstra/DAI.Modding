using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xml;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Utilities;
using DAI.ModMaker.Properties;

using Microsoft.Win32;

namespace DAI.ModMaker {
    public partial class TalktableEditor : Window, IComponentConnector {
        private Talktable.TalktableString SelectedString;

        private Thread ProcessThread;

        public TalktableEditor() {
            InitializeComponent();
            PreviewDeviceComboBox.Items.Add("PC");
            PreviewDeviceComboBox.Items.Add("PS3");
            PreviewDeviceComboBox.Items.Add("PS4");
            PreviewDeviceComboBox.Items.Add("XBOX360");
            PreviewDeviceComboBox.Items.Add("XBOXONE");
            PreviewDeviceComboBox.SelectedIndex = 0;
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e) {
            int selectionStart = TalkTableEntryText.SelectionStart;
            if (selectionStart != -1) {
                int selectionLength = selectionStart + TalkTableEntryText.SelectionLength;
                TalkTableEntryText.Text = TalkTableEntryText.Text.Insert(selectionLength, "</b>");
                TalkTableEntryText.Text = TalkTableEntryText.Text.Insert(selectionStart, "<b>");
                TalkTableEntryText.Select(0, 0);
            }
        }

        private void ChangeLanguageButton_Click(object sender, RoutedEventArgs e) {
            PopulateListBox("", (string)LanguagesComboBox.SelectedItem);
        }

        private void ExportMenuItem_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog {
                Title = "Save Talktable to XML",
                Filter = "*.xml|*.xml"
            };
            if (saveFileDialog.ShowDialog() != true) {
                return;
            }
            List<Talktable.TalktableString> allStrings = Library.GetAllStrings((string)LanguagesComboBox.SelectedItem);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
            stringBuilder.Append("<talktable>\n");
            foreach (Talktable.TalktableString item in allStrings) {
                string str = item.Value.Replace("\\", "\\\\");
                str = str.Replace("\r", "\\r");
                str = str.Replace("\n", "\\n");
                str = str.Replace(">", "&gt;");
                str = str.Replace("<", "&lt;");
                stringBuilder.AppendFormat(arg1: str.Replace("&", "&amp;"), format: "   <entry><id>{0}</id><text>{1}</text></entry>\n", arg0: item.ID.ToString("X8"));
            }
            stringBuilder.Append("</talktable>\n");
            StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
            streamWriter.Write(stringBuilder.ToString());
            streamWriter.Close();
            MessageBox.Show("Talktables saved to " + saveFileDialog.FileName);
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e) {
            string selectedItem = (string)LanguagesComboBox.SelectedItem;
            PopulateListBox(FilterTextBox.Text, selectedItem);
        }

        private void ImportMenuItem_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Title = "Open Talktable XML",
                Filter = "*.xml|*.xml"
            };
            if (openFileDialog.ShowDialog() != true) {
                return;
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(File.ReadAllText(openFileDialog.FileName, Encoding.UTF8));
            XmlNode xmlNode = xmlDocument.ChildNodes[1];
            List<Talktable.TalktableString> sTRs = new List<Talktable.TalktableString>();
            foreach (XmlNode childNode in xmlNode.ChildNodes) {
                Talktable.TalktableString sTR = new Talktable.TalktableString();
                foreach (XmlNode xmlNodes in childNode.ChildNodes) {
                    switch (xmlNodes.Name) {
                        case "id":
                            sTR.ID = Convert.ToUInt32(xmlNodes.InnerText, 16);
                            break;
                        case "text":
                            LibraryManager.ModifyString(sTR, xmlNodes.InnerText);
                            break;
                    }
                }
                if (sTR.ID != 0) {
                    sTRs.Add(sTR);
                }
            }
            foreach (Talktable.TalktableString sTR2 in sTRs) {
                string strValue = sTR2.Value.Replace("\\r", "\r");
                strValue = sTR2.Value.Replace("\\n", "\n");
                strValue = sTR2.Value.Replace("\\\r", "\\r");
                strValue = sTR2.Value.Replace("\\\n", "\\n");
                strValue = sTR2.Value.Replace("\\\\", "\\");
                strValue = sTR2.Value.Replace("&gt;", ">");
                strValue = sTR2.Value.Replace("&lt;", "<");
                strValue = sTR2.Value.Replace("&amp;", "&");
                if (!LibraryManager.ModifyString((string)LanguagesComboBox.SelectedItem, sTR2.ID, strValue)) {
                    LibraryManager.AddString((string)LanguagesComboBox.SelectedItem, sTR2.ID, strValue);
                }
            }
            PopulateListBox("", (string)LanguagesComboBox.SelectedItem);
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e) {
            int selectionStart = TalkTableEntryText.SelectionStart;
            if (selectionStart != -1) {
                int selectionLength = selectionStart + TalkTableEntryText.SelectionLength;
                TalkTableEntryText.Text = TalkTableEntryText.Text.Insert(selectionLength, "</i>");
                TalkTableEntryText.Text = TalkTableEntryText.Text.Insert(selectionStart, "<i>");
                TalkTableEntryText.Select(0, 0);
            }
        }

        private void PopulateListBox(string Filter, string LangID) {
            TalkTableListBox.Items.Clear();
            ProcessThread = new Thread((ThreadStart)delegate {
                List<Talktable.TalktableString> allStrings = Library.GetAllStrings(LangID);
                if (Filter != "") {
                    allStrings = allStrings.FindAll((Talktable.TalktableString A) => A.Value.ToLower().Contains(Filter.ToLower()));
                }
                int i = default(int);
                Talktable.TalktableString item = default(Talktable.TalktableString);
                for (i = 0; i < allStrings.Count; i++) {
                    item = allStrings[i];
                    UpdateProgressBar.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate {
                        TalkTableListBox.Items.Add(item);
                        UpdateProgressBar.Value = (float)i / (float)allStrings.Count * 100f;
                        return null;
                    }, null);
                }
            });
            ProcessThread.Start();
        }

        private void PreviewDeviceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            TextPreviewBlock.Inlines.Clear();
            TextPreviewBlock.Inlines.AddRange(DAI.ModMaker.Utilities.Utilities.ConvertStringToInlines(TalkTableEntryText.Text, (string)PreviewDeviceComboBox.SelectedItem));
        }

        private void SaveTextButton_Click(object sender, RoutedEventArgs e) {
            int selectedIndex = TalkTableListBox.SelectedIndex;
            LibraryManager.ModifyString(SelectedString, TalkTableEntryText.Text);
            TalkTableListBox.Items.RemoveAt(selectedIndex);
            TalkTableListBox.Items.Insert(selectedIndex, SelectedString);
        }

        private void StringButton_Click(object sender, RoutedEventArgs e) {
            int selectionStart = TalkTableEntryText.SelectionStart;
            if (selectionStart != -1) {
                int selectionLength = selectionStart + TalkTableEntryText.SelectionLength;
                TalkTableEntryText.Text = TalkTableEntryText.Text.Insert(selectionLength, "{/string}");
                TalkTableEntryText.Text = TalkTableEntryText.Text.Insert(selectionStart, "{string}");
                TalkTableEntryText.Select(0, 0);
            }
        }

        private void TalkTableEntryText_TextChanged(object sender, TextChangedEventArgs e) {
            TextPreviewBlock.Inlines.Clear();
            TextPreviewBlock.Inlines.AddRange(DAI.ModMaker.Utilities.Utilities.ConvertStringToInlines(TalkTableEntryText.Text, (string)PreviewDeviceComboBox.SelectedItem));
        }

        private void TalkTableListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (TalkTableListBox.SelectedIndex != -1) {
                SelectedString = (Talktable.TalktableString)TalkTableListBox.SelectedItem;
                TalkTableEntryText.Text = SelectedString.Value;
                TextPreviewBlock.Inlines.Clear();
                TextPreviewBlock.Inlines.AddRange(DAI.ModMaker.Utilities.Utilities.ConvertStringToInlines(SelectedString.Value, (string)PreviewDeviceComboBox.SelectedItem));
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e) {
            if (ProcessThread.IsAlive) {
                ProcessThread.Abort();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            List<string> allLanguages = Library.GetAllLanguages();
            LanguagesComboBox.ItemsSource = allLanguages;
            LanguagesComboBox.SelectedItem = Settings.Default.Language;
            PopulateListBox("", Settings.Default.Language);
        }
    }
}
