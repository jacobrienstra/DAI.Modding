using System.Collections.Generic;

namespace DAI.ModMaker.DAIMod
{
    public class ModBundle
    {
        public string Name;

        public string TocFilename;

        public int MagicSalt;

        public byte AlignMembers;

        public byte RidSupport;

        public byte StoreCompressedSizes;

        public string Action;

        public List<ModBundleEntry> Entries;

        public ModBundle()
        {
            Entries = new List<ModBundleEntry>();
        }

        public ModBundle(string InName, string InAction)
        {
            Name = InName;
            Action = InAction;
            Entries = new List<ModBundleEntry>();
        }
    }
}
