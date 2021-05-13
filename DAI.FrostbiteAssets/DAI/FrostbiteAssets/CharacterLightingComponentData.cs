using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CharacterLightingComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 TopLight { get; set; }

		[FieldOffset(128, 208)]
		public Vec3 BottomLight { get; set; }

		[FieldOffset(144, 224)]
		public Realm Realm { get; set; }

		[FieldOffset(148, 228)]
		public float CameraUpRotation { get; set; }

		[FieldOffset(152, 232)]
		public CharacterLightingMode CharacterLightingMode { get; set; }

		[FieldOffset(156, 236)]
		public float BlendFactor { get; set; }

		[FieldOffset(160, 240)]
		public float TopLightDirX { get; set; }

		[FieldOffset(164, 244)]
		public float TopLightDirY { get; set; }

		[FieldOffset(168, 248)]
		public float StartFadeDistance { get; set; }

		[FieldOffset(172, 252)]
		public float EndFadeDistance { get; set; }

		[FieldOffset(176, 256)]
		public bool CharacterLightEnable { get; set; }

		[FieldOffset(177, 257)]
		public bool FirstPersonEnable { get; set; }

		[FieldOffset(178, 258)]
		public bool LockToCameraDirection { get; set; }
	}
}
