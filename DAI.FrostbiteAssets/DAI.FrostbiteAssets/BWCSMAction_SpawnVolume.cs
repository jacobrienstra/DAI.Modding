namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SpawnVolume : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<RulesVolumeEntityData> RulesVolumeData { get; set; }
	}
}
