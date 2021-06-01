using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InputActionMouseAndLocalizedStringPair : LinkObject
	{
		[FieldOffset(0, 0)]
		public InputDeviceMouseButtons InputAction { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference InputActionString { get; set; }
	}
}
