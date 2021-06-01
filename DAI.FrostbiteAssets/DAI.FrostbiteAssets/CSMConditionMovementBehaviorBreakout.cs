namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionMovementBehaviorBreakout : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider_Self> Entity { get; set; }
	}
}
