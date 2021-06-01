namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityResourceBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo ClassType { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo AbilityResourcePercentage { get; set; }

		[FieldOffset(40, 88)]
		public UIDataSourceInfo LocalPlayerHealthPercentage { get; set; }

		[FieldOffset(56, 120)]
		public UIDataSourceInfo LocalPlayerMaxHealth { get; set; }

		[FieldOffset(72, 152)]
		public UIDataSourceInfo LocalPlayerBarrierPercentage { get; set; }

		[FieldOffset(88, 184)]
		public UIDataSourceInfo LocalPlayerArmorPercentage { get; set; }

		[FieldOffset(104, 216)]
		public UIDataSourceInfo LocalPlayerInCombat { get; set; }

		[FieldOffset(120, 248)]
		public UIDataSourceInfo LocalPlayerSelected { get; set; }

		[FieldOffset(136, 280)]
		public UIDataSourceInfo PCUsingGamePad { get; set; }

		[FieldOffset(152, 312)]
		public UIDataSourceInfo MPCharacterArchetype { get; set; }

		[FieldOffset(168, 344)]
		public UIDataSourceInfo DuelistData { get; set; }

		[FieldOffset(184, 376)]
		public UIDataSourceInfo AvvarData { get; set; }

		[FieldOffset(200, 408)]
		public UIDataSourceInfo BardClipName { get; set; }
	}
}
