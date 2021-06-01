namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProfileOptionDataInt : ProfileOptionData
	{
		[FieldOffset(20, 88)]
		public int Min { get; set; }

		[FieldOffset(24, 92)]
		public int Max { get; set; }

		[FieldOffset(28, 96)]
		public int Value { get; set; }

		[FieldOffset(32, 100)]
		public int Step { get; set; }
	}
}
