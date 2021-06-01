namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTargetInfoBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo HasTarget { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo IsTargetFriendly { get; set; }

		[FieldOffset(40, 88)]
		public UIDataSourceInfo TargetName { get; set; }

		[FieldOffset(56, 120)]
		public UIDataSourceInfo TargetHealthPercentage { get; set; }

		[FieldOffset(72, 152)]
		public UIDataSourceInfo TargetArmorPercentage { get; set; }

		[FieldOffset(88, 184)]
		public UIDataSourceInfo TargetBarrierPercentage { get; set; }

		[FieldOffset(104, 216)]
		public UIDataSourceInfo TargetRank { get; set; }

		[FieldOffset(120, 248)]
		public UIDataSourceInfo TargetLevel { get; set; }

		[FieldOffset(136, 280)]
		public UIDataSourceInfo TargetLevelDifference { get; set; }

		[FieldOffset(152, 312)]
		public bool IsBoss { get; set; }
	}
}
