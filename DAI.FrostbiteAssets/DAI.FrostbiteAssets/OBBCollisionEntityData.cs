using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class OBBCollisionEntityData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public Vec3 HalfExtents { get; set; }

		[FieldOffset(128, 224)]
		public OBBCollisionEntityLayer Layer { get; set; }

		[FieldOffset(132, 228)]
		public bool Slippery { get; set; }
	}
}
