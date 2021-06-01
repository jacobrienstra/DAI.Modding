using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemModificationAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ItemModification> Modifications { get; set; }

		public ItemModificationAsset()
		{
			Modifications = new List<ItemModification>();
		}
	}
}
