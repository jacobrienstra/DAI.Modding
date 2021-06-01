namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GiveStackedItemEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<StackedItemAsset> Item { get; set; }

		[FieldOffset(20, 104)]
		public int Count { get; set; }

		[FieldOffset(24, 108)]
		public bool ShowNotification { get; set; }
	}
}
