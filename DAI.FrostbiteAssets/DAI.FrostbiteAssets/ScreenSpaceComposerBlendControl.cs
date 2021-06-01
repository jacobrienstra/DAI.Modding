namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScreenSpaceComposerBlendControl
	{
		[FieldOffset(0, 0)]
		public float Scale { get; set; }

		[FieldOffset(4, 4)]
		public float InputThreshold { get; set; }

		[FieldOffset(8, 8)]
		public float Delay { get; set; }

		[FieldOffset(12, 12)]
		public float RateIn { get; set; }

		[FieldOffset(16, 16)]
		public float RateOut { get; set; }

		[FieldOffset(20, 20)]
		public bool Enabled { get; set; }
	}
}
