using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpgradeSet : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<UpgradeItemType>> UpgradeSlots { get; set; }

		public UpgradeSet()
		{
			UpgradeSlots = new List<ExternalObject<UpgradeItemType>>();
		}
	}
}
