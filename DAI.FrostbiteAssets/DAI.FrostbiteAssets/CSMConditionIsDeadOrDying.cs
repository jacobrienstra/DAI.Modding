namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionIsDeadOrDying : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Entity { get; set; }

		[FieldOffset(12, 40)]
		public bool NoEntityReturn { get; set; }
	}
}
