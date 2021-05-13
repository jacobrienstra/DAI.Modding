namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICreditsImage : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ImageTexturePath { get; set; }

		[FieldOffset(4, 8)]
		public float FadeInTime { get; set; }

		[FieldOffset(8, 12)]
		public float HoldTime { get; set; }

		[FieldOffset(12, 16)]
		public float FadeOutTime { get; set; }

		[FieldOffset(16, 20)]
		public float Delaytime { get; set; }
	}
}
