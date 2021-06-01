using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace DAI.Controls {
    public partial class ColorPickerDialog : Window, IComponentConnector {

        public Color SelectedColor => Color.FromArgb((byte)AlphaSlider.Value, (byte)RedSlider.Value, (byte)GreenSlider.Value, (byte)BlueSlider.Value);

        public ColorPickerDialog(Color InColor) {
            InitializeComponent();
            RedSlider.Value = (int)InColor.R;
            GreenSlider.Value = (int)InColor.G;
            BlueSlider.Value = (int)InColor.B;
            AlphaSlider.Value = (int)InColor.A;
        }

        private void AlphaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            AlphaTextBox.Text = AlphaSlider.Value.ToString();
        }

        private void BlueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            BlueTextBox.Text = BlueSlider.Value.ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            base.DialogResult = false;
        }

        private void GreenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            GreenTextBox.Text = GreenSlider.Value.ToString();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e) {
            base.DialogResult = true;
        }

        private void RedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            RedTextBox.Text = RedSlider.Value.ToString();
        }
    }
}
