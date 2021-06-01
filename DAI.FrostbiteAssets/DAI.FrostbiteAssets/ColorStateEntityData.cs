using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ColorStateEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 RGB { get; set; }

		[FieldOffset(32, 112)]
		public Realm Realm { get; set; }

		[FieldOffset(36, 116)]
		public float Alpha { get; set; }
	}
}
