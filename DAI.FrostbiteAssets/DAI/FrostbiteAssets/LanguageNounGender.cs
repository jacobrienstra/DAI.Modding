namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LanguageNounGender
	{
		[FieldOffset(0, 0)]
		public int NounGender { get; set; }

		[FieldOffset(4, 4)]
		public bool Possible { get; set; }
	}
}
