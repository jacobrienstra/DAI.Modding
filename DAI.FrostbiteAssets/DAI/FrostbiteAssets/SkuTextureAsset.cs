using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SkuTextureAsset : LinkObject
	{
		[FieldOffset(0, 0)]
		public SKU TargetSku { get; set; }

		[FieldOffset(4, 8)]
		public string TextureName { get; set; }
	}
}
