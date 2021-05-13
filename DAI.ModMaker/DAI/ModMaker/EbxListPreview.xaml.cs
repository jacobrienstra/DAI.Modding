using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;

namespace DAI.ModMaker
{
    public partial class EbxListPreview : Window, IComponentConnector
    {
        public EbxListPreview()
        {
            InitializeComponent();
            List<EbxRef> allEbx = Library.GetAllEbx();
            allEbx.Sort((EbxRef A, EbxRef B) => A.AssetType.CompareTo(B.AssetType));
            EbxListBox.ItemsSource = allEbx;
        }

        private void EbxListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EbxListBox.SelectedIndex != -1)
            {
                EbxRef selectedItem = (EbxRef)EbxListBox.SelectedItem;
                EbxBase dAIEbx = EbxBase.FromEbx(selectedItem);
                EbxNameText.Text = selectedItem.Name;
                EbxXmlText.Text = dAIEbx.ToXml();
            }
        }
    }
}
