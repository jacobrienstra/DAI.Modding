using System;
using System.Windows;
using System.Windows.Markup;

using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.ModMaker {
    public partial class HashWindow : Window, IComponentConnector {
        public HashWindow() {
            InitializeComponent();
        }

        private void FNVHashButton_Click(object sender, RoutedEventArgs e) {
            if (!(FNVSourceTextBox.Text == "")) {
                FNVDestTextBox.Text = "";
                byte[] bytes = BitConverter.GetBytes((FNVCaseSensitiveCB.IsChecked.Value ? FNVSourceTextBox.Text : FNVSourceTextBox.Text.ToLower()).Hash());
                for (int i = 0; i < bytes.Length; i++) {
                    FNVDestTextBox.Text = bytes[i].ToString("X2") + FNVDestTextBox.Text;
                }
            }
        }
    }
}
