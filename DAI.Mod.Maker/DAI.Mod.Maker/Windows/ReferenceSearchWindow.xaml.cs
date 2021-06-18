using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.Mod.Maker {
    public partial class ReferenceSearchWindow : Window, IComponentConnector {
        public ReferenceSearchWindow() {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void Search(EbxRef InSearchAsset, List<EbxRef> InSearchList) {
            EbxBase dAIEbx = EbxBase.FromEbx(InSearchAsset);
            ExternalGuid dAIExternalGuid = new ExternalGuid(dAIEbx.FileGuid, dAIEbx.Instances.Keys.ElementAt(0));
            new Thread((ThreadStart)delegate {
                List<EbxRef> ebxAssets = InSearchList.FindAll(delegate (EbxRef A) {
                    SearchResultsListBox.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate {
                        SearchStatusText.Text = A.Name;
                        return null;
                    }, null);
                    return EbxBase.FromEbx(A).ExternalGuids.FindIndex((ExternalGuid B) => !(B.FileGuid != dAIExternalGuid.FileGuid) && B.InstanceGuid == dAIExternalGuid.InstanceGuid) > 1;
                });
                SearchResultsListBox.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate {
                    SearchResultsListBox.ItemsSource = ebxAssets;
                    SearchStatusText.Text = "Found " + ebxAssets.Count + " reference(s)";
                    return null;
                }, null);
            }).Start();
        }

        private void SearchResultsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            EbxRef selectedItem = SearchResultsListBox.SelectedItem as EbxRef;
            if (selectedItem != null) {
                new EbxPreviewWindow(EbxBase.FromEbx(selectedItem)).Show();
            }
        }

        public bool? ShowDialog(EbxRef InSearchAsset, List<EbxRef> InSearchList) {
            SearchTextBox.Text = InSearchAsset.GetDisplayFullName();
            Search(InSearchAsset, InSearchList);
            return ShowDialog();
        }
    }
}
