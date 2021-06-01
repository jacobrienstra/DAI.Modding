namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIExpBarBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo CurExpPts { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo TotalExpPts { get; set; }

		[FieldOffset(40, 88)]
		public UIDataSourceInfo CurLevel { get; set; }

		[FieldOffset(56, 120)]
		public UIDataSourceInfo BannerLevel { get; set; }

		[FieldOffset(72, 152)]
		public UIDataSourceInfo BarUIState { get; set; }

		[FieldOffset(88, 184)]
		public UIDataSourceInfo BarLength { get; set; }

		[FieldOffset(104, 216)]
		public UIDataSourceInfo BannerShowTime { get; set; }

		[FieldOffset(120, 248)]
		public UIDataSourceInfo RecentGains { get; set; }
	}
}
