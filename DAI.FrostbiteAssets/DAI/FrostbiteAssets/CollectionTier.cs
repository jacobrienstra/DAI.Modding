namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CollectionTier : LinkObject
	{
		[FieldOffset(0, 0)]
		public PlotFlagReference UnlockAtCount { get; set; }

		[FieldOffset(16, 40)]
		public PlotFlagReference UnlockedStatus { get; set; }
	}
}
