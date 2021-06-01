namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameProjectileParabolaSteeringData : GameProjectileVelocityMoverModifierData
	{
		[FieldOffset(12, 32)]
		public GameProjectileParabola Parabola { get; set; }
	}
}
