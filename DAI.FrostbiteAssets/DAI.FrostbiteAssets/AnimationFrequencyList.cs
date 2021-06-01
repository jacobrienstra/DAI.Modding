using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AnimationFrequencyList : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<AnimationFrequency>> AnimationFrequencies { get; set; }

		public AnimationFrequencyList()
		{
			AnimationFrequencies = new List<ExternalObject<AnimationFrequency>>();
		}
	}
}
