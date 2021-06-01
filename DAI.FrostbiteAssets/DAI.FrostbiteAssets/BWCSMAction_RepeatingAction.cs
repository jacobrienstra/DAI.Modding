namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_RepeatingAction : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<BWCSMAction> Action { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<FloatProvider> RepeatTime { get; set; }
	}
}
