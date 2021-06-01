namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DynamicModelPhysicsComponentData : GamePhysicsComponentData
	{
		[FieldOffset(112, 208)]
		public Vec3 ImpulseInput { get; set; }
	}
}
