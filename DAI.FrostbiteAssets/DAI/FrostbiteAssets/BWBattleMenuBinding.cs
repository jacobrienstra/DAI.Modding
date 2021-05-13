namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWBattleMenuBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo Effects { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo EffectCooldowns { get; set; }

		[FieldOffset(40, 88)]
		public UIDataSourceInfo Visible { get; set; }

		[FieldOffset(56, 120)]
		public UIDataSourceInfo ResourceFrame { get; set; }

		[FieldOffset(72, 152)]
		public UIDataSourceInfo MomentumBarVisible { get; set; }

		[FieldOffset(88, 184)]
		public UIDataSourceInfo MomentumCount { get; set; }

		[FieldOffset(104, 216)]
		public UIDataSourceInfo CantCastFrame { get; set; }

		[FieldOffset(120, 248)]
		public UIDataSourceInfo ClassType { get; set; }

		[FieldOffset(136, 280)]
		public UIDataSourceInfo AnchorDischargeIcon { get; set; }

		[FieldOffset(152, 312)]
		public UIDataSourceInfo AnchorDischargeVisible { get; set; }

		[FieldOffset(168, 344)]
		public UIDataSourceInfo AnchorDischargeReadiness { get; set; }

		[FieldOffset(184, 376)]
		public UIDataSourceInfo AnchorDischargeInputEnabled { get; set; }
	}
}
