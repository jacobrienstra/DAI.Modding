namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_AdjustDepletableStatOverTime : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<BWDepletableStat> Stat { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<FloatProvider> AdjustmentRate { get; set; }

		[FieldOffset(36, 88)]
		public bool DisableRegeneration { get; set; }

		[FieldOffset(37, 89)]
		public bool IsPercentageOfMaxValue { get; set; }
	}
}
