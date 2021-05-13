using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;
using DAI.ModMaker;

namespace DAI.ModMaker.DAIModules.Preview
{
	public class LevelDataPreview : DAIBasePreviewer
	{
		public string[] GetAssetTypes()
		{
			return new string[2] { "LevelData", "SubWorldData" };
		}

		public void Run(AssetContainer InContainer, EbxRef InAsset)
		{
			new LevelDataPreviewWindow(InContainer, InAsset).Show();
		}
	}
}
