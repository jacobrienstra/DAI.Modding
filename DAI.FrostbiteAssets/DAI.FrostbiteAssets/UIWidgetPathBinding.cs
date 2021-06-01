namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIWidgetPathBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo WidgetPathQuery { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo Visibility { get; set; }
	}
}
