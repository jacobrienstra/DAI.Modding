using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NonAtlasedTextureResourceEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint Hash { get; set; }

		[FieldOffset(4, 8)]
		public List<uint> AltHashes { get; set; }

		[FieldOffset(8, 16)]
		public ExternalObject<TextureAsset> Asset { get; set; }

		public NonAtlasedTextureResourceEntry()
		{
			AltHashes = new List<uint>();
		}
	}
}
