namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementTransform : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec3 Rotation { get; set; }

		[FieldOffset(16, 16)]
		public Vec3 RotationPivot { get; set; }

		[FieldOffset(32, 32)]
		public float Z { get; set; }

		[FieldOffset(36, 40)]
		public string PropertyName { get; set; }
	}
}
