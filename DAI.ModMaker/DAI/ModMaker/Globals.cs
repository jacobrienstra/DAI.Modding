using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;

namespace DAI.ModMaker
{
    internal static class Globals
    {
        internal static EbxRef SelectedAsset;

        internal static bool WarnedAboutTextures;

        private static Lazy<Dictionary<uint, Dictionary<uint, MeshVariationDatabaseEntry>>> _meshVariations;

        internal static Dictionary<uint, Dictionary<uint, MeshVariationDatabaseEntry>> MeshVariations => _meshVariations.Value;

        internal static void SetMeshVariationLoad(Func<Dictionary<uint, Dictionary<uint, MeshVariationDatabaseEntry>>> factory)
        {
            _meshVariations = new Lazy<Dictionary<uint, Dictionary<uint, MeshVariationDatabaseEntry>>>(factory, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        internal static MeshVariationDatabaseEntry GetMeshVariation(uint InHash, uint InVariationHash = 0u)
        {
            if (!MeshVariations.ContainsKey(InHash))
            {
                return null;
            }
            if (!MeshVariations[InHash].ContainsKey(InVariationHash))
            {
                return null;
            }
            return MeshVariations[InHash][InVariationHash];
        }

        internal static List<MeshVariationDatabaseEntry> GetMeshVariations(uint InHash)
        {
            if (!MeshVariations.ContainsKey(InHash))
            {
                return null;
            }
            return MeshVariations[InHash].Values.ToList();
        }
    }
}
