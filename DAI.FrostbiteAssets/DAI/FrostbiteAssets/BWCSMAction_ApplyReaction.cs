namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyReaction : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public Delegate_float ForceComputation { get; set; }

		[FieldOffset(40, 96)]
		public BWCSMReactionTypeRef ReactionType { get; set; }
	}
}
