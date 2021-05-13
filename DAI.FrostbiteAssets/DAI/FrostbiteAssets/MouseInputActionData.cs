using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MouseInputActionData : AxesInputActionData
	{
		[FieldOffset(20, 40)]
		public InputDeviceMouseButtons Button { get; set; }

		[FieldOffset(24, 44)]
		public bool SimulateJoystickAxis { get; set; }

		[FieldOffset(25, 45)]
		public bool RememberExcessInput { get; set; }

		[FieldOffset(26, 46)]
		public bool ScaleScrollWheelAxisInput { get; set; }
	}
}
