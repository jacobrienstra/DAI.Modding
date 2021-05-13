namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class OBBData : BaseShapeData
	{
		[FieldOffset(16, 96)]
		public LinearTransform Transform { get; set; }

		[FieldOffset(80, 160)]
		public Vec3 HalfExtents { get; set; }
	}
}
