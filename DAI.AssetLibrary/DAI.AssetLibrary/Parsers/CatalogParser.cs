using System.Collections.Generic;
using System.IO;

using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities.Extensions;
using DAI.AssetLibrary.Utilities;

namespace DAI.AssetLibrary.Parsers {
    public static class CatalogParser {
        internal static Dictionary<Sha1, CatalogEntry> ParseAll(string basePath) {
            Dictionary<Sha1, CatalogEntry> catEntries = new Dictionary<Sha1, CatalogEntry>();
            string[] files = Directory.GetFiles(basePath, "*.cat", SearchOption.AllDirectories);
            foreach (string catPath in files) {
                Parse(basePath, catEntries, catPath);
            }
            return catEntries;
        }

        public static void Parse(string basePath, Dictionary<Sha1, CatalogEntry> catEntries, string catPath) {
            string directory = string.IsNullOrWhiteSpace(basePath) ? Path.GetDirectoryName(catPath) : Path.GetDirectoryName(catPath).Replace(basePath + "\\", "");
            using (MemoryStream ms = new MemoryStream(Utilities.Utils.DecodeFile(catPath))) {
                using (BinaryReader reader = new BinaryReader(ms)) {
                    reader.BaseStream.Seek(16L, SeekOrigin.Begin);
                    while (reader.BaseStream.Position < reader.BaseStream.Length) {
                        CatalogEntry catEntry = new CatalogEntry();
                        catEntry.Sha1 = reader.ReadSha1();
                        catEntry.Offset = reader.ReadInt32();
                        catEntry.Size = reader.ReadInt32();
                        catEntry.Path = $"{directory}\\cas_{reader.ReadInt32():00}.cas";
                        if (!catEntries.ContainsKey(catEntry.Sha1)) {
                            catEntries.Add(catEntry.Sha1, catEntry);
                        }
                    }
                }
            }
        }
    }
}
