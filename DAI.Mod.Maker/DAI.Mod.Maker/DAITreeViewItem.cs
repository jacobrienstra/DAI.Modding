using System.Windows.Controls;

namespace DAI.Mod.Maker {
    public class DAITreeViewItem : TreeViewItem {
        public object UserData;

        public DAITreeViewItem(object Folder) {
            UserData = Folder;
        }
    }
}
