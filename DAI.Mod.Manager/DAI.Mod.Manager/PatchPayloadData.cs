using System.Collections.Generic;

namespace DAI.Mod.Manager {
    public class PatchPayloadData {
        public string OutputPath { get; set; }

        public bool IncludeProjectData { get; set; }

        public bool CreateDistPatch { get; set; }

        public List<ModContainer> ModList { get; set; }
    }
}
