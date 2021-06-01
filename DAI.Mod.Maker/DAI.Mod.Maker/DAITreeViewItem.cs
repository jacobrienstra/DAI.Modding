using System.Windows.Controls;

namespace DAI.ModMaker {
    public class DAITreeViewItem : TreeViewItem {
        public object UserData;

        public DAITreeViewItem(object Folder) {
            UserData = Folder;
        }
    }
}
