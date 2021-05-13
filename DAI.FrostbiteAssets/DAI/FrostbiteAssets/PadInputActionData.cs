using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PadInputActionData : AxesInputActionData
	{
		[FieldOffset(20, 40)]
		public InputDevicePadButtons Button { get; set; }

		[FieldOffset(24, 44)]
		public InputDevicePadButtons PS3AlternativeButton { get; set; }

		[FieldOffset(28, 48)]
		public InputDevicePOVs Pov { get; set; }

		[FieldOffset(32, 52)]
		public bool UseSquareInput { get; set; }

		[FieldOffset(33, 53)]
		public bool IgnoreSuppression { get; set; }
	}
}
