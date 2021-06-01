namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootTableItem : BaseLootItem
	{
		[FieldOffset(24, 56)]
		public float Weight { get; set; }
	}
}
