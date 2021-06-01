using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBWInventoryCategories : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<UIBWInventoryComponentCategoryData> CategoryLabels { get; set; }

		public UIBWInventoryCategories()
		{
			CategoryLabels = new List<UIBWInventoryComponentCategoryData>();
		}
	}
}
