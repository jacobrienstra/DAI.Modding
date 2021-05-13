namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPartyMemberSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public ExternalObject<BWPartyMemberConfiguration> Configuration { get; set; }
	}
}
