namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIHeadMorphSliderSliderParameterGroup : UIHeadMorphSliderShaderParameter
	{
		[FieldOffset(32, 96)]
		public Vec4 SliderValue { get; set; }

		[FieldOffset(48, 112)]
		public ExternalObject<UIHeadMorphSliderSliderParameter> ComponentX { get; set; }

		[FieldOffset(52, 120)]
		public ExternalObject<UIHeadMorphSliderSliderParameter> ComponentY { get; set; }

		[FieldOffset(56, 128)]
		public ExternalObject<UIHeadMorphSliderSliderParameter> ComponentZ { get; set; }

		[FieldOffset(60, 136)]
		public ExternalObject<UIHeadMorphSliderSliderParameter> ComponentW { get; set; }
	}
}
