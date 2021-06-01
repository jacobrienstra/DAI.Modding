namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyDamageCalculationModifier : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public DamageCalculationModifier Modifier { get; set; }
	}
}
