using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SphereGeneratorGameProjectileLauncherData : GameProjectileLauncherBaseData
	{
		[FieldOffset(8, 24)]
		public ExternalObject<TransformProvider> LaunchTransformA { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<TransformProvider> LaunchTransformB { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<TransformProvider> InitialTargetAimPosition { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<TransformProvider> InitialTargetAimDirection { get; set; }

		[FieldOffset(24, 56)]
		public ExternalObject<TransformProvider> InitialDefaultAimPosition { get; set; }

		[FieldOffset(28, 64)]
		public ExternalObject<TransformProvider> InitialDefaultAimDirection { get; set; }

		[FieldOffset(32, 72)]
		public int ProjectilesSpawned { get; set; }

		[FieldOffset(36, 76)]
		public GameProjectileSpreadPattern SpreadPattern { get; set; }

		[FieldOffset(40, 80)]
		public uint Seed { get; set; }

		[FieldOffset(44, 88)]
		public ExternalObject<SphereGeneratorData> SourceSphereGenerator { get; set; }

		[FieldOffset(48, 96)]
		public bool SpawnFromTarget { get; set; }

		[FieldOffset(49, 97)]
		public bool SphereGeneratorAffectsTrajectory { get; set; }
	}
}
