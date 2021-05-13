namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMReactionOverrideSet : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public int ReactionPriority { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<BWCSMReactionSet> OverrideReactionSet { get; set; }
	}
}
