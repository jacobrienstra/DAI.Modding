namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMapBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo MapInfo { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo Pins { get; set; }

		[FieldOffset(40, 88)]
		public UIDataSourceInfo SelectedPin { get; set; }

		[FieldOffset(56, 120)]
		public UIDataSourceInfo Floors { get; set; }

		[FieldOffset(72, 152)]
		public UIDataSourceInfo Traveled { get; set; }

		[FieldOffset(88, 184)]
		public UIDataSourceInfo InfoPanel { get; set; }

		[FieldOffset(104, 216)]
		public UIDataSourceInfo ToolTip { get; set; }
	}
}
