using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EulerTransformEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 Trans { get; set; }

		[FieldOffset(32, 112)]
		public Realm Realm { get; set; }

		[FieldOffset(36, 116)]
		public float Rotation { get; set; }

		[FieldOffset(40, 120)]
		public ModifierEuler Euler { get; set; }
	}
}
