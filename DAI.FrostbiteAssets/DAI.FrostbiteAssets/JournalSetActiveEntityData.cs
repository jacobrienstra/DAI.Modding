namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JournalSetActiveEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<JournalAsset> JournalToActivate { get; set; }
	}
}
