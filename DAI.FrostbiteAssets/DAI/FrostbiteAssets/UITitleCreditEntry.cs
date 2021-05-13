namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITitleCreditEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public LocalizedStringReference Title { get; set; }

		[FieldOffset(4, 24)]
		public LocalizedStringReference Name { get; set; }

		[FieldOffset(8, 48)]
		public float FadeInTime { get; set; }

		[FieldOffset(12, 52)]
		public float HoldTime { get; set; }

		[FieldOffset(16, 56)]
		public float FadeOutTime { get; set; }

		[FieldOffset(20, 60)]
		public float Delaytime { get; set; }

		[FieldOffset(24, 64)]
		public float FontScale { get; set; }

		[FieldOffset(28, 68)]
		public float StartTime { get; set; }
	}
}
