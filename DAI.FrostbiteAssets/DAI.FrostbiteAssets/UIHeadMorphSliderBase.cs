namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphSliderBase : DataContainer
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference Title { get; set; }

		[FieldOffset(12, 48)]
		public int CameraId { get; set; }

		[FieldOffset(16, 56)]
		public string UsageId { get; set; }

		[FieldOffset(20, 64)]
		public uint UsageHash { get; set; }

		[FieldOffset(24, 68)]
		public bool Gen3Compatible { get; set; }
	}
}
