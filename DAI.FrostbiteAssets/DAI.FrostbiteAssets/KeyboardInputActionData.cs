using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class KeyboardInputActionData : InputActionData
	{
		[FieldOffset(12, 32)]
		public InputDeviceKeys Key { get; set; }
	}
}
