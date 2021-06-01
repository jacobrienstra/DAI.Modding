using System.Windows;
using System.Windows.Markup;

using DAI.Mod.Maker.Properties;

namespace DAI.Mod.Maker {
    public partial class MeshImportConfig : Window, IComponentConnector {
        public bool Cancelled { get; set; }

        public MeshImportConfig() {
            InitializeComponent();
            GlobalScaleTextBox.Text = Settings.Default.GlobalMeshScale.ToString("F3");
            Cancelled = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            float single = 0f;
            if (!float.TryParse(GlobalScaleTextBox.Text, out single)) {
                MessageBox.Show("Global Scale is in incorrect format, please try again");
                return;
            }
            Cancelled = false;
            Settings.Default.GlobalMeshScale = single;
            Settings.Default.Save();
            Close();
        }
    }
}
