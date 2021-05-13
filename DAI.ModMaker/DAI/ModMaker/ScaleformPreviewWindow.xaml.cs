using System.IO;
using System.Windows;
using System.Windows.Markup;

using Microsoft.Win32;

namespace DAI.ModMaker
{
    public partial class ScaleformPreviewWindow : Window, IComponentConnector
    {
        public ScaleformPreviewWindow(byte[] InData)
        {
            InitializeComponent();
            ResourceHexControl.SetByteData(InData);
            ResourceHexControl.MenuBarHidden = true;
        }

        private void ExtractButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save Resource",
                Filter = "*.bin|*.bin"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                byte[] byteData = ResourceHexControl.GetByteData();
                BinaryWriter binaryWriter = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.Create));
                binaryWriter.Write(byteData);
                binaryWriter.Close();
                MessageBox.Show("Resource saved to " + saveFileDialog.FileName);
            }
        }
    }
}
