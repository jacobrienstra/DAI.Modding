using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AxesInputActionData : InputActionData
	{
		[FieldOffset(12, 32)]
		public InputDeviceAxes Axis { get; set; }

		[FieldOffset(16, 36)]
		public bool NormalizeInput { get; set; }
	}
}
