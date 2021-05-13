namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyOverrideReactionSet : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<BWCSMReactionOverrideSet> OverrideReactionSet { get; set; }

		[FieldOffset(32, 80)]
		public int OverrideReactionType { get; set; }
	}
}
