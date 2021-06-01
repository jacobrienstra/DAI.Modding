namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OverrideReactionPair : LinkObject
	{
		[FieldOffset(0, 0)]
		public int OverrideReactionType { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<BWCSMReactionOverrideSet> OverrideReactionSet { get; set; }
	}
}
