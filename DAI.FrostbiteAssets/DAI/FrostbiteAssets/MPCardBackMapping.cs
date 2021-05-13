using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPCardBackMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public ItemQuality ItemQuality { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<TextureAsset> CardBackTexture { get; set; }
	}
}
