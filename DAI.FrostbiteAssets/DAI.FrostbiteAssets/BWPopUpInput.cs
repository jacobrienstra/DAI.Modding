using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPopUpInput : LinkObject
	{
		[FieldOffset(0, 0)]
		public BWPopUpButtonId ButtonId { get; set; }

		[FieldOffset(4, 4)]
		public UIInputAction InputAction { get; set; }

		[FieldOffset(8, 8)]
		public string OutputPinLabel { get; set; }

		[FieldOffset(12, 16)]
		public LocalizedStringReference DisplayLabel { get; set; }

		[FieldOffset(16, 40)]
		public bool UseInputAction { get; set; }
	}
}
