namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BaseLootItem : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<BaseItemAsset> ItemAsset { get; set; }

		[FieldOffset(12, 32)]
		public int MinQuantity { get; set; }

		[FieldOffset(16, 36)]
		public int MaxQuantity { get; set; }

		[FieldOffset(20, 40)]
		public int MaxPerArea { get; set; }
	}
}
