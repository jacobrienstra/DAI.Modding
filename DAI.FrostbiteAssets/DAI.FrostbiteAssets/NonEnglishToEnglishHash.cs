namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NonEnglishToEnglishHash
	{
		[FieldOffset(0, 0)]
		public uint NonEnglishHash { get; set; }

		[FieldOffset(4, 4)]
		public uint EnglishHash { get; set; }
	}
}
