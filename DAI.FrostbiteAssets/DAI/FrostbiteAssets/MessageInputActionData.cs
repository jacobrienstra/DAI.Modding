using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MessageInputActionData : InputActionData
	{
		[FieldOffset(12, 32)]
		public InputDeviceMessageEvent Command { get; set; }
	}
}
