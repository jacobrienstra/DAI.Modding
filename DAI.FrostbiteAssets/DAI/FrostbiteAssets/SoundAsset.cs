using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<SoundScopeData> Scope { get; set; }

		[FieldOffset(16, 80)]
		public List<SoundDataReference> ReferencedData { get; set; }

		public SoundAsset()
		{
			ReferencedData = new List<SoundDataReference>();
		}
	}
}
