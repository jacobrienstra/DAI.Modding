using System;

using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;

namespace DAI.ModMaker.Utilities
{
    public static class Extensions
    {
        public static string GetDisplayFullName(this EbxRef ebx)
        {
            string ebxName = ebx.Name;
            int index = ebxName.LastIndexOf("/");
            if (index != -1)
            {
                ebxName = ebxName.Substring(index + 1);
            }
            return $"[{ebx.AssetType}] {ebxName}";
        }

        public static AssetContainer GetContainer(this EbxBase ebx)
        {
            try
            {
                return new AssetContainer(ebx);
            }
            catch (Exception)
            {
                return new AssetContainer();
            }
        }
    }
}
