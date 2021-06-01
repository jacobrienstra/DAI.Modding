namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionDamageType : BWConditional
	{
		[FieldOffset(8, 32)]
		public int DamageType { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<ExplicitEquipSlotProvider> Slot { get; set; }
	}
}
