namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPGameEventConfigurationSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public string StatsRulesJSON { get; set; }
	}
}
