using System.Text;
using System.Windows;
using System.Windows.Markup;

using DAI.FrostbiteAssets;

namespace DAI.ModMaker {
    public partial class PrefabBlueprintPreviewWindow : Window, IComponentConnector {
        public PrefabBlueprintPreviewWindow(PrefabBlueprint InBlueprint) {
            InitializeComponent();
            StringBuilder stringBuilder = new StringBuilder();
            Blueprint blueprint = InBlueprint;
            foreach (PropertyConnection propertyConnection in blueprint.PropertyConnections) {
                stringBuilder.AppendFormat("{0} -> {1}\n", propertyConnection.Source.ToString(), propertyConnection.Target.ToString());
            }
            PrefabTextBox.Text = stringBuilder.ToString();
        }
    }
}
