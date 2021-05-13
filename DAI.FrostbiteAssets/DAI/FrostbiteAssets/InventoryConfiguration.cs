namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InventoryConfiguration : SystemSettings
	{
		[FieldOffset(16, 40)]
		public ExternalObject<PlayerCurrencies> Currencies { get; set; }

		[FieldOffset(20, 48)]
		public PlotFlagReference InventoryCapacity { get; set; }

		[FieldOffset(36, 88)]
		public PlotConditionReference PlotCondition { get; set; }

		[FieldOffset(64, 168)]
		public PlotConditionReference DisableEquip { get; set; }

		[FieldOffset(92, 248)]
		public uint MaxGold { get; set; }
	}
}
