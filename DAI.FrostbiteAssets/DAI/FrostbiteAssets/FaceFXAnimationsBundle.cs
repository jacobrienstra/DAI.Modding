using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceFXAnimationsBundle : LinkObject
	{
		[FieldOffset(0, 0)]
		public LanguageFormat Language { get; set; }

		[FieldOffset(4, 8)]
		public BlueprintBundleReference Bundle { get; set; }
	}
}
