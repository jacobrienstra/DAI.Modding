namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProfileOptionDataFloat : ProfileOptionData
	{
		[FieldOffset(20, 88)]
		public float Min { get; set; }

		[FieldOffset(24, 92)]
		public float Max { get; set; }

		[FieldOffset(28, 96)]
		public float Value { get; set; }

		[FieldOffset(32, 100)]
		public float Step { get; set; }
	}
}
