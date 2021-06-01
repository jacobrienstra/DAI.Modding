namespace DAI.AssetLibrary.Utilities {
    public class GameAssetFolder {
        public string Path { get; set; }

        public FolderType FolderType { get; set; }

        public GameAssetFolder(string path, FolderType folderType) {
            Path = path;
            FolderType = folderType;
        }
    }
}
