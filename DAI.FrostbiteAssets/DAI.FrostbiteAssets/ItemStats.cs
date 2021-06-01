using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemStats : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<BWModifiableItemStatValuePair> Stats { get; set; }

		public ItemStats()
		{
			Stats = new List<BWModifiableItemStatValuePair>();
		}
	}
}
