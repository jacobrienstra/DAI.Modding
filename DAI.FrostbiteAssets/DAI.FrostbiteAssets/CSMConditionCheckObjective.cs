namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionCheckObjective : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Entity { get; set; }

		[FieldOffset(12, 40)]
		public int Objective { get; set; }
	}
}
