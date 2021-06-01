using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWButtonLegendEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public string DisplayLabel { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference LocalizedDisplayString { get; set; }

		[FieldOffset(8, 32)]
		public UIInputAction InputAction { get; set; }

		[FieldOffset(12, 36)]
		public UIAnalogInput AnalogInput { get; set; }

		[FieldOffset(16, 40)]
		public UIButtonLegendIconDisplayType IconDisplayType { get; set; }

		[FieldOffset(20, 44)]
		public UIButtonLegendButtonState ButtonState { get; set; }

		[FieldOffset(24, 48)]
		public UIButtonLegendInterfaceMode ButtonInterfaceMode { get; set; }

		[FieldOffset(28, 52)]
		public bool Disabled { get; set; }
	}
}
