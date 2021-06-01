namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProfileOptionDataString : ProfileOptionData
	{
		[FieldOffset(20, 88)]
		public int MaxLength { get; set; }

		[FieldOffset(24, 96)]
		public string Value { get; set; }
	}
}
