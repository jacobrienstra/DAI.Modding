namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PotionHerbCost : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<StackedItemAsset> HerbAsset { get; set; }

		[FieldOffset(4, 8)]
		public byte Amount { get; set; }
	}
}
