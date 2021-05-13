using System.Windows;
using System.Windows.Markup;

namespace DAI.ModMaker
{
    public partial class ModConfiguration : Window, IComponentConnector
    {
        public bool Cancelled { get; set; }

        public string ModAuthor { get; set; }

        public string ModDescription { get; set; }

        public string ModTitle { get; set; }

        public string ModVersion { get; set; }

        public ModConfiguration(string InTitle, string InAuthor, string InVersion, string InDescription)
        {
            InitializeComponent();
            ModTitleTextBox.Text = InTitle;
            ModAuthorTextBox.Text = InAuthor;
            ModVersionTextBox.Text = InVersion;
            ModDescriptionTextBox.Text = InDescription;
            Cancelled = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Cancelled = true;
            Close();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Cancelled = false;
            ModTitle = ModTitleTextBox.Text;
            ModAuthor = ModAuthorTextBox.Text;
            ModVersion = ModVersionTextBox.Text;
            ModDescription = ModDescriptionTextBox.Text;
            Close();
        }
    }
}
