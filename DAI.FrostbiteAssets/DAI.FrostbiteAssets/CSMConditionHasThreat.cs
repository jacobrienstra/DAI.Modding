namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionHasThreat : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<AutoTarget> HaterEntity { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<EntityProvider_Self> HatedEntity { get; set; }

		[FieldOffset(16, 48)]
		public bool CheckMostHated { get; set; }
	}
}
