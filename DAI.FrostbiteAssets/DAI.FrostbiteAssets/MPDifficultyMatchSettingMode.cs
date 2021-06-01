namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPDifficultyMatchSettingMode : MPMatchSettingMode
	{
		[FieldOffset(40, 120)]
		public ExternalObject<DifficultyMode> DifficultyModeReference { get; set; }
	}
}
