using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphTargetBundleReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<MorphTargetHeadCharacteristics> Heads { get; set; }

		public MorphTargetBundleReference()
		{
			Heads = new List<MorphTargetHeadCharacteristics>();
		}
	}
}
