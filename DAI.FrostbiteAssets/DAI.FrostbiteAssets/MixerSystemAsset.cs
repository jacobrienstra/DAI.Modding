using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerSystemAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<MixGroup>> Groups { get; set; }

		public MixerSystemAsset()
		{
			Groups = new List<ExternalObject<MixGroup>>();
		}
	}
}
