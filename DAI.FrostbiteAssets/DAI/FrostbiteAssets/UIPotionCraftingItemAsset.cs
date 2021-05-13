using System;
using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPotionCraftingItemAsset : UITreeFlowAsset
	{
		[FieldOffset(64, 216)]
		public UITreeFlowChildType ChildListType { get; set; }

		[FieldOffset(68, 224)]
		public UITextureAtlasTextureReference UpgradeResearchedIcon { get; set; }

		[FieldOffset(88, 264)]
		public List<ExternalObject<UIPotionCraftingItemAsset>> RequiredResearch { get; set; }

		[FieldOffset(92, 272)]
		public UpgradeRequirementType RequirementType { get; set; }

		[FieldOffset(96, 276)]
		public Guid AbilityGuid { get; set; }

		public UIPotionCraftingItemAsset()
		{
			RequiredResearch = new List<ExternalObject<UIPotionCraftingItemAsset>>();
		}
	}
}
