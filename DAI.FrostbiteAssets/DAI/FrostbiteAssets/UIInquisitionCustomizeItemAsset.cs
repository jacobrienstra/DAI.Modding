using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIInquisitionCustomizeItemAsset : UITreeFlowAsset
	{
		[FieldOffset(64, 216)]
		public UITextureAtlasTextureReference BackgroundTexture { get; set; }

		[FieldOffset(84, 256)]
		public UITextureAtlasTextureReference IconTexture { get; set; }

		[FieldOffset(104, 296)]
		public UITreeFlowChildType ChildListType { get; set; }

		[FieldOffset(108, 300)]
		public UIInquisitionPerkCategoryType InqCategory { get; set; }

		[FieldOffset(112, 304)]
		public List<ExternalObject<UIInquisitionCustomizeItemAsset>> RequiredPerks { get; set; }

		[FieldOffset(116, 312)]
		public int RequiredPerksInCategory { get; set; }

		[FieldOffset(120, 320)]
		public PlotFlagReference PurchasedPlotFlag { get; set; }

		[FieldOffset(136, 360)]
		public PlotActionReference PerkAction { get; set; }

		[FieldOffset(160, 432)]
		public bool IsAgentPerk { get; set; }

		[FieldOffset(161, 433)]
		public bool IsRequirementStub { get; set; }

		public UIInquisitionCustomizeItemAsset()
		{
			RequiredPerks = new List<ExternalObject<UIInquisitionCustomizeItemAsset>>();
		}
	}
}
