using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SetLocalizationPlayerVariantEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LocalizedStringVariant Variant { get; set; }
	}
}
