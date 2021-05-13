using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Markup;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.References;
using DAI.ModMaker.Properties;

namespace DAI.ModMaker
{
    public partial class MeshExportConfig : Window, IComponentConnector
    {
        public bool Cancelled { get; set; }

        public EbxRef SelectedSkeleton
        {
            get
            {
                if (SkeletonComboBox.SelectedIndex == -1)
                {
                    return null;
                }
                return (EbxRef)SkeletonComboBox.SelectedItem;
            }
        }

        public MeshExportConfig(bool bShowSkeletonOption = false)
        {
            InitializeComponent();
            GlobalScaleTextBox.Text = Settings.Default.GlobalMeshScale.ToString("F3");
            Cancelled = true;
            if (!bShowSkeletonOption)
            {
                SkeletonTextBlock.Visibility = Visibility.Collapsed;
                SkeletonComboBox.Visibility = Visibility.Collapsed;
                return;
            }
            List<EbxRef> list = (from A in Library.GetAllEbx()
                                 where A.AssetType == "SkeletonAsset"
                                 select A).ToList();
            list.Sort((EbxRef A, EbxRef B) => A.Name.CompareTo(B.Name));
            foreach (EbxRef ebxAsset in list)
            {
                SkeletonComboBox.Items.Add(ebxAsset);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            float single = 0f;
            if (!float.TryParse(GlobalScaleTextBox.Text, out single))
            {
                MessageBox.Show("Global Scale is in incorrect format, please try again");
                return;
            }
            if (SkeletonComboBox.Visibility == Visibility.Visible && SkeletonComboBox.SelectedIndex < 1)
            {
                MessageBox.Show("Skeleton selection is invalid, please try again");
                return;
            }
            Cancelled = false;
            Settings.Default.GlobalMeshScale = single;
            Settings.Default.Save();
            Close();
        }
    }
}
