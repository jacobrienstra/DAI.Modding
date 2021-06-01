using System.IO;

namespace DAI.ModManager.Utils {
    public class Settings {
        public const string ApplicationVersion = "v0.49 alpha";

        public static string BasePath { get; set; }

        public static string ModPath { get; set; }

        public static int PatchVersion { get; set; }

        public static bool RescanPatch { get; set; }

        public static bool VerboseScan { get; set; }

        public static string CurrentVersion { get; set; }

        public static void SetDefaults() {
            ModPath = "";
            PatchVersion = -1;
            RescanPatch = false;
            VerboseScan = false;
            CurrentVersion = "";
        }

        public static void Load() {
            StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\daimodmanager.ini");
            while (!streamReader.EndOfStream) {
                string[] array = streamReader.ReadLine().Split('=');
                if (array[0].Trim().ToLower() == "basepath") {
                    BasePath = array[1].Trim();
                } else if (array[0].Trim().ToLower() == "modpath") {
                    ModPath = array[1].Trim();
                } else if (array[0].Trim().ToLower() == "patchversion") {
                    PatchVersion = int.Parse(array[1].Trim());
                } else if (array[0].Trim().ToLower() == "version") {
                    CurrentVersion = array[1].Trim();
                }
            }
            streamReader.Close();
        }

        public static void Save() {
            StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "\\daimodmanager.ini");
            streamWriter.WriteLine("BasePath=" + BasePath);
            streamWriter.WriteLine("ModPath=" + ModPath);
            streamWriter.WriteLine("PatchVersion=" + PatchVersion);
            streamWriter.WriteLine("Version=" + CurrentVersion);
            streamWriter.Close();
        }
    }
}
