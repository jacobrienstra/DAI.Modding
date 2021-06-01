using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CraftingSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public PlotFlagReference MasterworkUnlockedPlotFlag { get; set; }

		[FieldOffset(28, 112)]
		public PlotFlagReference MasterworkBonusPercentagePlotFlag { get; set; }

		[FieldOffset(44, 152)]
		public LocalizedStringReference RecipeRequiresText { get; set; }

		[FieldOffset(48, 176)]
		public List<uint> RecipeTierMaxLevels { get; set; }

		[FieldOffset(52, 184)]
		public float RecipeLevelMaterialValueMultiplier { get; set; }

		public CraftingSettings()
		{
			RecipeTierMaxLevels = new List<uint>();
		}
	}
}
