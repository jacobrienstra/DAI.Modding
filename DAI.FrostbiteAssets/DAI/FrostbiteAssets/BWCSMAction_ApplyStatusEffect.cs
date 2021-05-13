namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyStatusEffect : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<StatusEffect> StatusEffect { get; set; }
	}
}
