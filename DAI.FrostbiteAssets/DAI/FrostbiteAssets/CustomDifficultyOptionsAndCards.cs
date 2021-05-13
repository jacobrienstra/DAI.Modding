namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CustomDifficultyOptionsAndCards : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<UIGameOptionsItemAsset> OptionAsset { get; set; }

		[FieldOffset(4, 8)]
		public string TarotCardName { get; set; }
	}
}
