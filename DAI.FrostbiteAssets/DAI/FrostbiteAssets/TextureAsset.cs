using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class TextureAsset : TextureBaseAsset
	{
		[FieldOffset(24, 80)]
		public AlphaMipmapFilterType AlphaMipmapFilter { get; set; }
	}
}
