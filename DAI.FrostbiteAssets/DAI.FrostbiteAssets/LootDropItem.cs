namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootDropItem : BaseLootItem
	{
		[FieldOffset(24, 56)]
		public PlotConditionReference PlotFlag { get; set; }

		[FieldOffset(52, 136)]
		public float DropProbability { get; set; }

		[FieldOffset(56, 140)]
		public bool Equiped { get; set; }
	}
}
