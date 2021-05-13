namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_Unspawn : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public bool OnEnd { get; set; }
	}
}
