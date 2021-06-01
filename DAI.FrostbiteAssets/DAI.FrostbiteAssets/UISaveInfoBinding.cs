namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISaveInfoBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo Level_ImagePath { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo HeroCard1_ImagePath { get; set; }

		[FieldOffset(40, 88)]
		public UIDataSourceInfo HeroCard2_ImagePath { get; set; }

		[FieldOffset(56, 120)]
		public UIDataSourceInfo HeroCard3_ImagePath { get; set; }

		[FieldOffset(72, 152)]
		public UIDataSourceInfo Details01_CategoryText { get; set; }

		[FieldOffset(88, 184)]
		public UIDataSourceInfo Details01_DetailText { get; set; }

		[FieldOffset(104, 216)]
		public UIDataSourceInfo Details02_CategoryText { get; set; }

		[FieldOffset(120, 248)]
		public UIDataSourceInfo Details02_DetailText { get; set; }

		[FieldOffset(136, 280)]
		public UIDataSourceInfo Details03_CategoryText { get; set; }

		[FieldOffset(152, 312)]
		public UIDataSourceInfo Details03_DetailText { get; set; }

		[FieldOffset(168, 344)]
		public UIDataSourceInfo Details04_CategoryText { get; set; }

		[FieldOffset(184, 376)]
		public UIDataSourceInfo Details04_DetailText { get; set; }

		[FieldOffset(200, 408)]
		public UIDataSourceInfo Details05_CategoryText { get; set; }

		[FieldOffset(216, 440)]
		public UIDataSourceInfo Details05_DetailText { get; set; }
	}
}
