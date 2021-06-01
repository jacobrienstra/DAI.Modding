namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RemoveItemEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public uint ItemID { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<BaseItemAsset> Item { get; set; }

		[FieldOffset(24, 112)]
		public int Count { get; set; }
	}
}
