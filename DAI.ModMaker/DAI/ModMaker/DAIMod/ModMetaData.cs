using System.Collections.Generic;

namespace DAI.ModMaker.DAIMod
{
    public class ModMetaData
    {
        public byte FormatVersion;

        public string ID;

        public byte MinPatchVersion;

        public int ToolSetVersion;

        public ModDetail Details;

        public List<ModReq> Requirements;

        public List<ModResourceEntry> Resources;

        public List<ModBundle> Bundles;

        public ModMetaData()
        {
            Details = new ModDetail();
            Requirements = new List<ModReq>();
            Bundles = new List<ModBundle>();
            Resources = new List<ModResourceEntry>();
        }

        public ModMetaData(byte InVersion, int InToolSetVersion, string InID, byte InMinPatchVersion, ModDetail InDetails)
        {
            FormatVersion = InVersion;
            ID = InID;
            ToolSetVersion = InToolSetVersion;
            MinPatchVersion = InMinPatchVersion;
            Details = InDetails;
            Requirements = new List<ModReq>();
            Bundles = new List<ModBundle>();
            Resources = new List<ModResourceEntry>();
        }
    }
}
