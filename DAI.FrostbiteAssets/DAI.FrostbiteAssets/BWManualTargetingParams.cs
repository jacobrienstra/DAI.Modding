namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWManualTargetingParams : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec3 Offset { get; set; }

		[FieldOffset(16, 16)]
		public ExternalObject<BWTweakableFloatProvider> Radius { get; set; }

		[FieldOffset(20, 24)]
		public float MinDistance { get; set; }

		[FieldOffset(24, 28)]
		public float MaxDistance { get; set; }

		[FieldOffset(28, 32)]
		public ExternalObject<ReachableTransform> StartingTargetingLocation { get; set; }

		[FieldOffset(32, 40)]
		public float MaxTerrainDeflection { get; set; }

		[FieldOffset(36, 48)]
		public ExternalObject<CinebotModeData> CameraMode { get; set; }

		[FieldOffset(40, 56)]
		public ExternalObject<BWVisualEffectEntityData> TargetingVFX { get; set; }

		[FieldOffset(44, 64)]
		public ExternalObject<Dummy> PendingVFX { get; set; }

		[FieldOffset(48, 72)]
		public ExternalObject<BWTweakableFloatProvider> TargetingVFXScalingFactor { get; set; }

		[FieldOffset(52, 80)]
		public bool DetachCamera { get; set; }

		[FieldOffset(53, 81)]
		public bool AttachedAoE { get; set; }
	}
}
