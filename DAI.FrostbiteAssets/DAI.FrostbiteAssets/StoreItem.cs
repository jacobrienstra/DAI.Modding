namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StoreItem : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BaseItemAsset> Item { get; set; }

		[FieldOffset(4, 8)]
		public PlotConditionReference UnlockPlotCondition { get; set; }

		[FieldOffset(32, 88)]
		public int NumberInStock { get; set; }
	}
}
