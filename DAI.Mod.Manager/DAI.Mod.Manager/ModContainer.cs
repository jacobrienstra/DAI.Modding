using DAI.Utilities;

namespace DAI.Mod.Manager {
    public class ModContainer : NotificationObject {
        public string Path { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public int Index { get; set; }

        public bool IsOfficialPatch { get; set; }

        private bool _isEnabled;
        public bool IsEnabled {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public int MinPatchVersion { get; set; }

        public ModJob Mod { get; set; }

        public ModContainer(string InPath, string InName, string InAuthor, string InVersion, string InDescription, int InMinPatchVersion = -1) {
            Path = InPath;
            Name = InName;
            Author = InAuthor;
            Version = InVersion;
            Description = InDescription;
            MinPatchVersion = InMinPatchVersion;
            Index = 0;
            IsOfficialPatch = false;
            IsEnabled = MinPatchVersion == -1 || Settings.PatchVersion >= MinPatchVersion;
            Mod = null;
        }

        public bool IsDAIMod() {
            return Mod != null;
        }

        public override string ToString() {
            return Name;
        }
    }
}
