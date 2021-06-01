using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Recipe : BaseItemAsset
	{
		[FieldOffset(80, 248)]
		public LocalizedStringReference CraftingName { get; set; }

		[FieldOffset(84, 272)]
		public List<ExternalObject<DataContainer>> Slots { get; set; }

		[FieldOffset(88, 280)]
		public ExternalObject<StatItemAsset> ItemPattern { get; set; }

		[FieldOffset(92, 288)]
		public uint Level { get; set; }

		[FieldOffset(96, 292)]
		public RecipeQuality Quality { get; set; }

		[FieldOffset(100, 296)]
		public bool DeleteRecipeAfterCraft { get; set; }

		[FieldOffset(101, 297)]
		public bool DeleteCraftedItemAfterCraft { get; set; }

		public Recipe()
		{
			Slots = new List<ExternalObject<DataContainer>>();
		}
	}
}
