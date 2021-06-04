using System.Collections.Generic;

namespace DAI.Mod {
    public class ModMetaData {
        public byte FormatVersion;

        public string ID;

        public byte MinPatchVersion;

        public int ToolSetVersion;

        public ModDetail Details;

        public List<ModReq> Requirements;

        public List<ChunkModResourceEntry> Resources;

        public List<ModBundle> Bundles;

        public List<string> CopyFiles;

        public ModMetaData() {
            Details = new ModDetail();
            Requirements = new List<ModReq>();
            Bundles = new List<ModBundle>();
            Resources = new List<ChunkModResourceEntry>();
            CopyFiles = new List<string>();
        }

        public ModMetaData(byte InVersion, int InToolSetVersion, string InID, byte InMinPatchVersion, ModDetail InDetails) {
            FormatVersion = InVersion;
            ID = InID;
            ToolSetVersion = InToolSetVersion;
            MinPatchVersion = InMinPatchVersion;
            Details = InDetails;
            Requirements = new List<ModReq>();
            Bundles = new List<ModBundle>();
            Resources = new List<ChunkModResourceEntry>();
            CopyFiles = new List<string>();
        }
    }
}
