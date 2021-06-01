
namespace DAI.Utilities {
    public static class Meta {

        public static string MetaToString(byte[] InMeta) {
            if (InMeta == null) {
                return string.Empty;
            }
            string str = "";
            for (int i = 0; i < InMeta.Length; i++) {
                str += InMeta[i].ToString("X2");
            }
            return str;
        } 
    }
}
