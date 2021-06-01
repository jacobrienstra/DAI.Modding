using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundDataAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<SoundDataChunk> Chunks { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<SoundDataPolicy> Policy { get; set; }

		[FieldOffset(20, 88)]
		public byte PrimePriority { get; set; }

		[FieldOffset(21, 89)]
		public byte RequestPriority { get; set; }

		public SoundDataAsset()
		{
			Chunks = new List<SoundDataChunk>();
		}
	}
}
