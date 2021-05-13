namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotIncrementIntegerByValueEntityData : PlotIncrementIntegerBaseEntityData
	{
		[FieldOffset(32, 136)]
		public int Value { get; set; }
	}
}
