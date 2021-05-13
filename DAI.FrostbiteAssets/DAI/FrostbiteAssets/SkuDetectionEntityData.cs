using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SkuDetectionEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public SKU SkuToTest { get; set; }
	}
}
