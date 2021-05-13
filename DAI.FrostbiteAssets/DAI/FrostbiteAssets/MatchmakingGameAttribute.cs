namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingGameAttribute : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Attribute { get; set; }

		[FieldOffset(4, 8)]
		public string Value { get; set; }

		[FieldOffset(8, 16)]
		public bool Override { get; set; }
	}
}
