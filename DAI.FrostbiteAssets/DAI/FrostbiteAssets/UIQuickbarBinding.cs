namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIQuickbarBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo SlotData { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo IsPaused { get; set; }

		[FieldOffset(40, 88)]
		public UIDataSourceInfo IsTacCam { get; set; }

		[FieldOffset(56, 120)]
		public UIDataSourceInfo PlayerPortrait { get; set; }

		[FieldOffset(72, 152)]
		public UIDataSourceInfo ClassType { get; set; }

		[FieldOffset(88, 184)]
		public UIDataSourceInfo PlayerAbilityResourcePercentage { get; set; }

		[FieldOffset(104, 216)]
		public UIDataSourceInfo PlayerAbilityResourceVisible { get; set; }

		[FieldOffset(120, 248)]
		public UIDataSourceInfo Momentum { get; set; }

		[FieldOffset(136, 280)]
		public UIDataSourceInfo Effects { get; set; }

		[FieldOffset(152, 312)]
		public UIDataSourceInfo EffectCooldowns { get; set; }
	}
}
