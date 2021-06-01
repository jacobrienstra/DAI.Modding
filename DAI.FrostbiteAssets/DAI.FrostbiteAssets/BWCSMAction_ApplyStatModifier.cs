namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyStatModifier : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<BWModifiableStat> Stat { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<FloatProvider> ModifierAmount { get; set; }
	}
}
