namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWRadarBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo Visibility { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo CameraFacing { get; set; }

		[FieldOffset(40, 88)]
		public UIDataSourceInfo PlayerFacing { get; set; }

		[FieldOffset(56, 120)]
		public UIDataSourceInfo GoalInfos { get; set; }

		[FieldOffset(72, 152)]
		public UIDataSourceInfo ClampedInfos { get; set; }

		[FieldOffset(88, 184)]
		public UIDataSourceInfo SearchZones { get; set; }

		[FieldOffset(104, 216)]
		public UIDataSourceInfo CreatureInfos { get; set; }

		[FieldOffset(120, 248)]
		public UIDataSourceInfo OffScreenArrows { get; set; }

		[FieldOffset(136, 280)]
		public UIDataSourceInfo UserWaypoint { get; set; }

		[FieldOffset(152, 312)]
		public UIDataSourceInfo SearchAbility { get; set; }
	}
}
