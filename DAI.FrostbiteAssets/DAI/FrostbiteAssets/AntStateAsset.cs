using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntStateAsset : Asset
	{
		[FieldOffset(12, 72)]
		public Guid StreamingGuid { get; set; }

		[FieldOffset(28, 88)]
		public int ChunkSize { get; set; }
	}
}
