using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PropertyGateEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 Vec3In { get; set; }

		[FieldOffset(32, 112)]
		public Vec4 Vec4In { get; set; }

		[FieldOffset(48, 128)]
		public LinearTransform TransformIn { get; set; }

		[FieldOffset(112, 192)]
		public Realm Realm { get; set; }

		[FieldOffset(116, 196)]
		public int IntIn { get; set; }

		[FieldOffset(120, 200)]
		public float FloatIn { get; set; }

		[FieldOffset(124, 204)]
		public bool Default { get; set; }

		[FieldOffset(125, 205)]
		public bool WritePropertyOnOpenGate { get; set; }

		[FieldOffset(126, 206)]
		public bool BoolIn { get; set; }
	}
}
