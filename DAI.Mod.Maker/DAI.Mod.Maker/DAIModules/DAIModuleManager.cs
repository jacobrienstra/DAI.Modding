using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DAI.ModMaker.DAIModules {
    public static class DAIModuleManager {
        public static Dictionary<string, DAIBaseImporter> Importers;

        public static Dictionary<string, DAIBaseExporter> Exporters;

        public static Dictionary<string, DAIBasePreviewer> Previewers;

        static DAIModuleManager() {
            Importers = new Dictionary<string, DAIBaseImporter>();
            Exporters = new Dictionary<string, DAIBaseExporter>();
            Previewers = new Dictionary<string, DAIBasePreviewer>();
        }

        public static DAIBaseExporter GetExporter(string AssetType) {
            if (!Exporters.ContainsKey(AssetType)) {
                return null;
            }
            return Exporters[AssetType];
        }

        public static DAIBaseImporter GetImporter(string AssetType) {
            if (!Importers.ContainsKey(AssetType)) {
                return null;
            }
            return Importers[AssetType];
        }

        public static DAIBasePreviewer GetPreviewer(string AssetType) {
            if (!Previewers.ContainsKey(AssetType)) {
                return null;
            }
            return Previewers[AssetType];
        }

        public static bool HasExporter(string AssetType) {
            return Exporters.ContainsKey(AssetType);
        }

        public static bool HasImporter(string AssetType) {
            return Importers.ContainsKey(AssetType);
        }

        public static bool HasPreviewer(string AssetType) {
            return Previewers.ContainsKey(AssetType);
        }

        public static void LoadModules() {
            try {
                (from t in Assembly.GetExecutingAssembly().GetTypes()
                 where t.Namespace == "DAI.ModMaker.DAIModules.Import"
                 select t).ToList().ForEach(delegate (Type A) {
                     ConstructorInfo constructor3 = A.GetConstructor(Type.EmptyTypes);
                     if (constructor3 != null && constructor3.IsPublic) {
                         DAIBaseImporter dAIBaseImporter = constructor3.Invoke(null) as DAIBaseImporter;
                         if (dAIBaseImporter != null) {
                             string[] assetTypes3 = dAIBaseImporter.GetAssetTypes();
                             foreach (string key3 in assetTypes3) {
                                 Importers.Add(key3, dAIBaseImporter);
                             }
                         }
                     }
                 });
                (from t in Assembly.GetExecutingAssembly().GetTypes()
                 where t.Namespace == "DAI.ModMaker.DAIModules.Export"
                 select t).ToList().ForEach(delegate (Type A) {
                     ConstructorInfo constructor2 = A.GetConstructor(Type.EmptyTypes);
                     if (constructor2 != null && constructor2.IsPublic) {
                         DAIBaseExporter dAIBaseExporter = constructor2.Invoke(null) as DAIBaseExporter;
                         if (dAIBaseExporter != null) {
                             string[] assetTypes2 = dAIBaseExporter.GetAssetTypes();
                             foreach (string key2 in assetTypes2) {
                                 Exporters.Add(key2, dAIBaseExporter);
                             }
                         }
                     }
                 });
                (from t in Assembly.GetExecutingAssembly().GetTypes()
                 where t.Namespace == "DAI.ModMaker.DAIModules.Preview"
                 select t).ToList().ForEach(delegate (Type A) {
                     ConstructorInfo constructor = A.GetConstructor(Type.EmptyTypes);
                     if (constructor != null && constructor.IsPublic) {
                         DAIBasePreviewer dAIBasePreviewer = constructor.Invoke(null) as DAIBasePreviewer;
                         if (dAIBasePreviewer != null) {
                             string[] assetTypes = dAIBasePreviewer.GetAssetTypes();
                             foreach (string key in assetTypes) {
                                 Previewers.Add(key, dAIBasePreviewer);
                             }
                         }
                     }
                 });
            } catch (Exception ex) {
                new FrmException(ex, false);
            }
        }
    }
}
