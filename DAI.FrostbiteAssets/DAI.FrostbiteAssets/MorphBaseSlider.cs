using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphBaseSlider : DataContainer
	{
		[FieldOffset(8, 24)]
		public MorphSliderType SliderType { get; set; }

		[FieldOffset(12, 28)]
		public float DefaultWeight { get; set; }

		[FieldOffset(16, 32)]
		public bool DisableAdditiveBoneOffsets { get; set; }

		[FieldOffset(17, 33)]
		public bool EnabledWithHair { get; set; }

		[FieldOffset(18, 34)]
		public bool EnabledWithBeard { get; set; }

		[FieldOffset(19, 35)]
		public bool EnabledWithHorns { get; set; }

		[FieldOffset(20, 36)]
		public bool DebugOnly { get; set; }
	}
}
