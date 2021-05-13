using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWAutoTargetingSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public float DistanceToAngleWeighting { get; set; }

		[FieldOffset(16, 80)]
		public BWManualTargetingParams PositionTargetingParams { get; set; }

		[FieldOffset(80, 176)]
		public float PlaceableWeight { get; set; }

		[FieldOffset(84, 180)]
		public float InteractableWeightInRange { get; set; }

		[FieldOffset(88, 184)]
		public float InteractableWeightOutOfRange { get; set; }

		[FieldOffset(92, 188)]
		public float DistancePower { get; set; }

		[FieldOffset(96, 192)]
		public float AnglePower { get; set; }

		[FieldOffset(100, 196)]
		public float Stickiness { get; set; }

		[FieldOffset(104, 200)]
		public float CutAngleDeflected { get; set; }

		[FieldOffset(108, 204)]
		public float CutAngleUndeflected { get; set; }

		[FieldOffset(112, 208)]
		public float CutAngleBackoff { get; set; }

		[FieldOffset(116, 212)]
		public float CameraCullIgnoreRadius { get; set; }

		[FieldOffset(120, 216)]
		public ExternalObject<BWRange> MaximumRange { get; set; }

		[FieldOffset(124, 224)]
		public float LockTargetDistanceToAngleWeighting { get; set; }

		[FieldOffset(128, 228)]
		public float LockTargetDistancePower { get; set; }

		[FieldOffset(132, 232)]
		public float LockTargetAnglePower { get; set; }

		[FieldOffset(136, 236)]
		public float LockTargetCutAngle { get; set; }

		[FieldOffset(140, 240)]
		public float LockTargetTimeToCycle { get; set; }

		[FieldOffset(144, 244)]
		public float LockTargetCycleTime { get; set; }

		[FieldOffset(148, 248)]
		public float TargetingAnalogDeadZone { get; set; }

		[FieldOffset(152, 252)]
		public float PositionTranslationSpeed { get; set; }

		[FieldOffset(156, 256)]
		public float PositionYawSpeed { get; set; }

		[FieldOffset(160, 260)]
		public float DirectionYawSpeed { get; set; }

		[FieldOffset(164, 264)]
		public float PositionTargetingDistanceSpeed { get; set; }

		[FieldOffset(168, 268)]
		public float AOEDeadZone { get; set; }

		[FieldOffset(172, 272)]
		public ExternalObject<Dummy> TargetingErrorVFX { get; set; }

		[FieldOffset(176, 280)]
		public ExternalObject<EffectBlueprint> InvalidAOEPositionVFX { get; set; }

		[FieldOffset(180, 288)]
		public ExternalObject<ProfileOptionDataBool> PauseWhileAOECasting { get; set; }

		[FieldOffset(184, 296)]
		public float AOEYawSpeed { get; set; }

		[FieldOffset(188, 300)]
		public float AOEDistanceSpeed { get; set; }

		[FieldOffset(192, 304)]
		public float AOEStrafeSpeed { get; set; }

		[FieldOffset(196, 308)]
		public float AOEThrottleSpeed { get; set; }

		[FieldOffset(200, 312)]
		public float AttachedAOEYawSpeed { get; set; }

		[FieldOffset(204, 320)]
		public List<BWTimelineTagRef> RangedTargetingTags { get; set; }

		[FieldOffset(208, 328)]
		public List<BWTimelineTagRef> MeleeTargetingOverrideTags { get; set; }

		[FieldOffset(212, 336)]
		public float RangedTargetingStickiness { get; set; }

		public BWAutoTargetingSettings()
		{
			RangedTargetingTags = new List<BWTimelineTagRef>();
			MeleeTargetingOverrideTags = new List<BWTimelineTagRef>();
		}
	}
}
