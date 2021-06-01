namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_Asset : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public ExternalObject<BWCSMSyncReactionSet> Value { get; set; }
	}
}
