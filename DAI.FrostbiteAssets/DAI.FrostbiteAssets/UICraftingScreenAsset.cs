using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICraftingScreenAsset : UIItemScreenAsset
	{
		[FieldOffset(76, 208)]
		public List<UICraftingCategoryData> Categories { get; set; }

		[FieldOffset(80, 216)]
		public List<ExternalObject<WidgetNode>> UpgradeOrder { get; set; }

		public UICraftingScreenAsset()
		{
			Categories = new List<UICraftingCategoryData>();
			UpgradeOrder = new List<ExternalObject<WidgetNode>>();
		}
	}
}
