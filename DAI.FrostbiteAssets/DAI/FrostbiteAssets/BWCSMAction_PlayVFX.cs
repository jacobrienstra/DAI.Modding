using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_PlayVFX : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<BWVisualEffectEntityData> VisualEffectData { get; set; }

		[FieldOffset(32, 80)]
		public Vec3 PositionOffset { get; set; }

		[FieldOffset(48, 96)]
		public Vec3 Orientation { get; set; }

		[FieldOffset(64, 112)]
		public int AttachToId { get; set; }

		[FieldOffset(68, 116)]
		public BWVFXType VFXType { get; set; }

		[FieldOffset(72, 120)]
		public float Scale { get; set; }

		[FieldOffset(76, 124)]
		public SpawnEntityReference ReferenceA { get; set; }

		[FieldOffset(80, 128)]
		public SpawnEntityReference ReferenceB { get; set; }

		[FieldOffset(84, 132)]
		public SpawnEntityReference ReferenceC { get; set; }

		[FieldOffset(88, 136)]
		public int SourceBoneId { get; set; }

		[FieldOffset(92, 140)]
		public int TargetBoneId { get; set; }

		[FieldOffset(96, 144)]
		public bool StayAttached { get; set; }

		[FieldOffset(97, 145)]
		public bool UseImpactPoint { get; set; }

		[FieldOffset(98, 146)]
		public bool PreserveEffectOrientation { get; set; }

		[FieldOffset(99, 147)]
		public bool OffsetFromCharacterForward { get; set; }
	}
}
