namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ClearObjective : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<Dummy> Entity { get; set; }
	}
}
