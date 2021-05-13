namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilitiesUIBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo BattleMenuIconNames { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo AbilityTreeInfo { get; set; }
	}
}
