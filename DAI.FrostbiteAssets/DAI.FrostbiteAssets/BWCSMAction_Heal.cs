namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_Heal : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public Delegate_float HealAmount { get; set; }
	}
}
