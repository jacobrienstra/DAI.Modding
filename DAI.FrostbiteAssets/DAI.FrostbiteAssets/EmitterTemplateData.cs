using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EmitterTemplateData : DataContainer
	{
		[FieldOffset(8, 24)]
		public uint MaxCount { get; set; }

		[FieldOffset(12, 28)]
		public float Lifetime { get; set; }

		[FieldOffset(16, 32)]
		public Vec3 WorldAlignmentDirection { get; set; }

		[FieldOffset(32, 48)]
		public Vec3 OrientToPosition { get; set; }

		[FieldOffset(48, 64)]
		public Vec4 ParticleCollisionThrottleByDistance { get; set; }

		[FieldOffset(64, 80)]
		public Vec3 FallbackPlaneNormal { get; set; }

		[FieldOffset(80, 96)]
		public Vec3 FallbackPlanePosition { get; set; }

		[FieldOffset(96, 112)]
		public Vec3 FallbackPlaneSize { get; set; }

		[FieldOffset(112, 128)]
		public float TimeScale { get; set; }

		[FieldOffset(116, 132)]
		public uint LifetimeFrameCount { get; set; }

		[FieldOffset(120, 136)]
		public float KillRibbonTailDistance { get; set; }

		[FieldOffset(124, 140)]
		public EmittableType EmittableType { get; set; }

		[FieldOffset(128, 144)]
		public EmittableAlignment EmittableAlignment { get; set; }

		[FieldOffset(132, 148)]
		public TimeDomain TimeDomain { get; set; }

		[FieldOffset(136, 152)]
		public float MotionStretchMultiplier { get; set; }

		[FieldOffset(140, 156)]
		public float MotionStretchViewMultiplier { get; set; }

		[FieldOffset(144, 160)]
		public float MotionStretchLengthClamp { get; set; }

		[FieldOffset(148, 164)]
		public float MotionStretchRelativeLengthClamp { get; set; }

		[FieldOffset(152, 168)]
		public ExternalObject<RigidMeshAsset> Mesh { get; set; }

		[FieldOffset(156, 176)]
		public ExternalObject<ObjectVariation> Variation { get; set; }

		[FieldOffset(160, 184)]
		public EmitterCollisionType CollisionType { get; set; }

		[FieldOffset(164, 188)]
		public float CollisionFactor { get; set; }

		[FieldOffset(168, 192)]
		public float ParticleCollisionThrottle { get; set; }

		[FieldOffset(172, 196)]
		public float ParticleCollisionThrottleFarDistance { get; set; }

		[FieldOffset(176, 200)]
		public MaterialDecl MaterialPair { get; set; }

		[FieldOffset(180, 216)]
		public float VertexPixelLightingBlendFactor { get; set; }

		[FieldOffset(184, 220)]
		public float GlobalLocalNormalBlendFactor { get; set; }

		[FieldOffset(188, 224)]
		public float SoftParticlesFadeDistanceMultiplier { get; set; }

		[FieldOffset(192, 228)]
		public float LightWrapAroundFactor { get; set; }

		[FieldOffset(196, 232)]
		public float BentNormalFactor { get; set; }

		[FieldOffset(200, 236)]
		public float LightMultiplier { get; set; }

		[FieldOffset(204, 240)]
		public float BendingFactor { get; set; }

		[FieldOffset(208, 244)]
		public float CameraBias { get; set; }

		[FieldOffset(212, 248)]
		public SurfaceShaderInstanceDataStruct Shader { get; set; }

		[FieldOffset(232, 288)]
		public float AnimationFrameCount { get; set; }

		[FieldOffset(236, 292)]
		public float AnimationFrameColumnCount { get; set; }

		[FieldOffset(240, 296)]
		public EmitterDrawOrder EmitterDrawOrder { get; set; }

		[FieldOffset(244, 304)]
		public ExternalObject<EffectBlueprint> DeathEffect { get; set; }

		[FieldOffset(248, 312)]
		public float CollisionSpeedMinimum { get; set; }

		[FieldOffset(252, 316)]
		public OrientationSelection CollisionEffectOrientation { get; set; }

		[FieldOffset(256, 320)]
		public int CollisionCountToDisableRaychecks { get; set; }

		[FieldOffset(260, 324)]
		public int CollisionCountToEnableFallbackPlane { get; set; }

		[FieldOffset(264, 328)]
		public PlaneSelection FallbackPlane { get; set; }

		[FieldOffset(268, 332)]
		public float ParticleCullingFactor { get; set; }

		[FieldOffset(272, 336)]
		public float MinSpawnDistance { get; set; }

		[FieldOffset(276, 340)]
		public float MaxSpawnDistance { get; set; }

		[FieldOffset(280, 344)]
		public float MinScreenArea { get; set; }

		[FieldOffset(284, 348)]
		public float MeshCullingDistance { get; set; }

		[FieldOffset(288, 352)]
		public float DistanceScaleLength { get; set; }

		[FieldOffset(292, 356)]
		public float DistanceScaleNearValue { get; set; }

		[FieldOffset(296, 360)]
		public float DistanceScaleFarValue { get; set; }

		[FieldOffset(300, 364)]
		public float SpeedNormalizationValue { get; set; }

		[FieldOffset(304, 368)]
		public float WindSpeedNormalizationValue { get; set; }

		[FieldOffset(308, 376)]
		public List<ExternalObject<EffectParameter>> PerParticleEffectParameters { get; set; }

		[FieldOffset(312, 384)]
		public float CullFadeNearDistance { get; set; }

		[FieldOffset(316, 388)]
		public float CullFadeNearRange { get; set; }

		[FieldOffset(320, 392)]
		public float CullFadeFarDistance { get; set; }

		[FieldOffset(324, 396)]
		public float CullFadeFarRange { get; set; }

		[FieldOffset(328, 400)]
		public List<ProcessorDataEntry> Processors { get; set; }

		[FieldOffset(332, 408)]
		public bool RepeatParticleSpawning { get; set; }

		[FieldOffset(333, 409)]
		public bool FollowSpawnSource { get; set; }

		[FieldOffset(334, 410)]
		public bool KillParticlesWithEmitter { get; set; }

		[FieldOffset(335, 411)]
		public bool SmoothRibbonSpawn { get; set; }

		[FieldOffset(336, 412)]
		public bool ExclusionVolumeCullEnable { get; set; }

		[FieldOffset(337, 413)]
		public bool IsCollisionable { get; set; }

		[FieldOffset(338, 414)]
		public bool DontCheckWater { get; set; }

		[FieldOffset(339, 415)]
		public bool DontCheckTerrain { get; set; }

		[FieldOffset(340, 416)]
		public bool DontCheckRagdoll { get; set; }

		[FieldOffset(341, 417)]
		public bool DontCheckCharacter { get; set; }

		[FieldOffset(342, 418)]
		public bool Emissive { get; set; }

		[FieldOffset(343, 419)]
		public bool Opaque { get; set; }

		[FieldOffset(344, 420)]
		public bool ReceiveSunShadow { get; set; }

		[FieldOffset(345, 421)]
		public bool ForceNiceSorting { get; set; }

		[FieldOffset(346, 422)]
		public bool LocalSpace { get; set; }

		[FieldOffset(347, 423)]
		public bool AllowScale { get; set; }

		[FieldOffset(348, 424)]
		public bool CameraSpace { get; set; }

		[FieldOffset(349, 425)]
		public bool TransparencySunShadowEnable { get; set; }

		[FieldOffset(350, 426)]
		public bool CastPlanarReflectionEnable { get; set; }

		[FieldOffset(351, 427)]
		public bool ForceFullRes { get; set; }

		[FieldOffset(352, 428)]
		public bool FogFade { get; set; }

		[FieldOffset(353, 429)]
		public bool LockRibbonDirection { get; set; }

		[FieldOffset(354, 430)]
		public bool CollisionEffectOnExpire { get; set; }

		[FieldOffset(355, 431)]
		public bool FallbackPlaneNormalIsLocal { get; set; }

		[FieldOffset(356, 432)]
		public bool FallbackPlanePositionIsLocal { get; set; }

		[FieldOffset(357, 433)]
		public bool FallbackPlaneSizeIsLocal { get; set; }

		[FieldOffset(358, 434)]
		public bool AcceptGlobalParameter1 { get; set; }

		[FieldOffset(359, 435)]
		public bool AcceptGlobalParameter2 { get; set; }

		[FieldOffset(360, 436)]
		public bool AcceptGlobalParameter3 { get; set; }

		[FieldOffset(361, 437)]
		public bool EmitterWindEvaluationEnable { get; set; }

		[FieldOffset(362, 438)]
		public bool EmittableWindEvaluationEnable { get; set; }

		public EmitterTemplateData()
		{
			PerParticleEffectParameters = new List<ExternalObject<EffectParameter>>();
			Processors = new List<ProcessorDataEntry>();
		}
	}
}
