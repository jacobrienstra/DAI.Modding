using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DofParameters : LinkObject
	{
		[FieldOffset(0, 0)]
		public float FocusDistance { get; set; }

		[FieldOffset(4, 4)]
		public BlurFilter Filter { get; set; }

		[FieldOffset(8, 8)]
		public float DofMaxBlur { get; set; }

		[FieldOffset(12, 12)]
		public float DofNearEnd { get; set; }

		[FieldOffset(16, 16)]
		public float DofNearStart { get; set; }

		[FieldOffset(20, 20)]
		public float DofFarStart { get; set; }

		[FieldOffset(24, 24)]
		public float DofFarEnd { get; set; }

		[FieldOffset(28, 32)]
		public ExternalObject<Dummy> Aperture { get; set; }
	}
}
