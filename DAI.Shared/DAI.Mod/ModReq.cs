namespace DAI.Mod {
    public class ModReq {
        public string ID;

        public string MinVersion;

        public ModReq(string InID, string InMinVersion) {
            ID = InID;
            MinVersion = InMinVersion;
        }
    }
}
