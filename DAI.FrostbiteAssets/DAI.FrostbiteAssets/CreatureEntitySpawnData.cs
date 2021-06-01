namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureEntitySpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference CharacterNameReference { get; set; }

		[FieldOffset(12, 48)]
		public ExternalObject<CharacterPhysicsData> CharacterPhysics { get; set; }
	}
}
