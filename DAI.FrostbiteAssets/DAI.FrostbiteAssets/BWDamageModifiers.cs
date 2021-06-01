using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWDamageModifiers : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<BWDamageTypePairing> Modifiers { get; set; }

		public BWDamageModifiers()
		{
			Modifiers = new List<BWDamageTypePairing>();
		}
	}
}
