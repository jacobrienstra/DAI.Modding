using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;

namespace DAI.ModManager {
    public partial class ProgressWindow : Window, IComponentConnector {
        private bool LegitClose;

        public ProgressWindow() {
            InitializeComponent();
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e) {
            LegitClose = true;
            Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e) {
            if (!LegitClose) {
                e.Cancel = true;
            }
        }
    }
}
