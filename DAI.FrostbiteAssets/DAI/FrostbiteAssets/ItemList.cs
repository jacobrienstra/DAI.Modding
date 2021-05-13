using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemList : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<BaseItemAsset>> ItemAssets { get; set; }

		public ItemList()
		{
			ItemAssets = new List<ExternalObject<BaseItemAsset>>();
		}
	}
}
