namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPotionIndicatorBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo IndicatorVisible { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo MPPotions { get; set; }
	}
}
