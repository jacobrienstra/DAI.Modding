namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InquisitionPerkManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public PlotFlagReference InquisitionPerkPointsFlag { get; set; }

		[FieldOffset(32, 136)]
		public ExternalObject<UIInquisitionCustomizeItemAsset> RootNode { get; set; }
	}
}
