namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LanguageNounNumber
	{
		[FieldOffset(0, 0)]
		public int NounNumber { get; set; }

		[FieldOffset(4, 4)]
		public bool Possible { get; set; }
	}
}
