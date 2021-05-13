namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SphereCollisionEntityData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public Vec3 Position { get; set; }

		[FieldOffset(128, 224)]
		public float Radius { get; set; }
	}
}
