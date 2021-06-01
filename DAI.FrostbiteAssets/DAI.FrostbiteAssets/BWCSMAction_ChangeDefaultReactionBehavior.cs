namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ChangeDefaultReactionBehavior : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<BWCSMReactionSet> ReactionSet { get; set; }

		[FieldOffset(32, 80)]
		public bool IgnoreOverrideReactions { get; set; }
	}
}
