using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphSliderSliderParameter : UIHeadMorphSliderShaderParameter
	{
		[FieldOffset(32, 96)]
		public SliderParameterAffectVectorComponent AffectVectorComponent { get; set; }

		[FieldOffset(36, 100)]
		public float SliderStep { get; set; }

		[FieldOffset(40, 104)]
		public float SliderMin { get; set; }

		[FieldOffset(44, 108)]
		public float SliderMax { get; set; }

		[FieldOffset(48, 112)]
		public bool Ignore { get; set; }
	}
}
