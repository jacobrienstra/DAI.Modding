namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CharacterPhysicsComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<CharacterPhysicsData> CharacterPhysics { get; set; }

		[FieldOffset(100, 184)]
		public bool EnableCollisionOnSpawn { get; set; }
	}
}
