namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionCompareSlots : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<ContextEquipSlotProvider> SlotA { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<ExplicitEquipSlotProvider> SlotB { get; set; }
	}
}
