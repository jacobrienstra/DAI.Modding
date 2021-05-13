using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovieTextureAsset : Asset
	{
		[FieldOffset(12, 72)]
		public Guid ChunkGuid { get; set; }

		[FieldOffset(28, 88)]
		public uint ChunkSize { get; set; }

		[FieldOffset(32, 92)]
		public Guid SubtitleChunkGuid { get; set; }

		[FieldOffset(48, 108)]
		public uint SubtitleChunkSize { get; set; }

		[FieldOffset(52, 112)]
		public bool HasLocalizedAudioTracks { get; set; }

		[FieldOffset(53, 113)]
		public bool OverrideBackgroundMusic { get; set; }

		[FieldOffset(54, 114)]
		public bool HasVp6 { get; set; }

		[FieldOffset(55, 115)]
		public bool HasVp8 { get; set; }
	}
}
