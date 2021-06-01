namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureProfileExtraSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public ExternalObject<CreatureProfile> CreatureProfile { get; set; }
	}
}
