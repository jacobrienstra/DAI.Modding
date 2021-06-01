namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GiveItemEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<BaseItemAsset> Item { get; set; }

		[FieldOffset(20, 104)]
		public bool ShowNotification { get; set; }
	}
}
