using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NewGamePlusSet : DataContainer
	{
		[FieldOffset(8, 24)]
		public string SetName { get; set; }

		[FieldOffset(12, 32)]
		public int DLCPackage { get; set; }

		[FieldOffset(16, 40)]
		public List<PlotFlagReference> PlotFlags { get; set; }

		[FieldOffset(20, 48)]
		public List<RecipeReference> Recipes { get; set; }

		[FieldOffset(24, 56)]
		public List<StackedItemReference> StackedItems { get; set; }

		public NewGamePlusSet()
		{
			PlotFlags = new List<PlotFlagReference>();
			Recipes = new List<RecipeReference>();
			StackedItems = new List<StackedItemReference>();
		}
	}
}
