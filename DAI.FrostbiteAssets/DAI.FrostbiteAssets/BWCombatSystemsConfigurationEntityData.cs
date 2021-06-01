namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCombatSystemsConfigurationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<BWCombatSystemsConfiguration> Configuration { get; set; }
	}
}
