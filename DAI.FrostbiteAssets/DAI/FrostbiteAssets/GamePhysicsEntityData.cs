namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GamePhysicsEntityData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public ExternalObject<PhysicsEntityData> PhysicsData { get; set; }
	}
}
