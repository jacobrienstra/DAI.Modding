namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SphereData : BaseShapeData
	{
		[FieldOffset(16, 96)]
		public Vec3 Position { get; set; }

		[FieldOffset(32, 112)]
		public float Radius { get; set; }
	}
}
