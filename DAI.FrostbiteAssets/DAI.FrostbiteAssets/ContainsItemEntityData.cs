namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ContainsItemEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<BaseItemAsset> Item { get; set; }

		[FieldOffset(20, 104)]
		public int Count { get; set; }
	}
}
