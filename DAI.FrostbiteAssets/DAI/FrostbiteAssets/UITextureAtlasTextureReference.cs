using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITextureAtlasTextureReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint AtlasTextureHash { get; set; }

		[FieldOffset(4, 4)]
		public Guid AtlasGuid { get; set; }
	}
}
