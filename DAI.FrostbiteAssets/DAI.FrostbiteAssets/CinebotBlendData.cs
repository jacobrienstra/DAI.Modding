namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotBlendData : CameraTransition
	{
		[FieldOffset(8, 24)]
		public float TimeToDelay { get; set; }

		[FieldOffset(12, 28)]
		public float Time { get; set; }

		[FieldOffset(16, 32)]
		public float EaseInControl { get; set; }

		[FieldOffset(20, 36)]
		public float EaseOutControl { get; set; }
	}
}
