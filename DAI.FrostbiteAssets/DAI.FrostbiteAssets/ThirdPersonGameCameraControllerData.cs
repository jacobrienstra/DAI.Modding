using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ThirdPersonGameCameraControllerData : CinebotControllerData
	{
		[FieldOffset(24, 112)]
		public float FOV { get; set; }

		[FieldOffset(28, 120)]
		public string AnchorPart { get; set; }

		[FieldOffset(32, 128)]
		public Vec3 Offset { get; set; }

		[FieldOffset(48, 144)]
		public Vec3 BoomOffset { get; set; }

		[FieldOffset(64, 160)]
		public Vec3 CameraSpaceTargetOffset { get; set; }

		[FieldOffset(80, 176)]
		public Vec3 CollisionHookOffset { get; set; }

		[FieldOffset(96, 192)]
		public Vec3 AlternateCollisionHookOffset { get; set; }

		[FieldOffset(112, 208)]
		public Vec3 SpringMaxElongation { get; set; }

		[FieldOffset(128, 224)]
		public Vec3 HeightAdjustmentBoneLocalPosition { get; set; }

		[FieldOffset(144, 240)]
		public List<ThirdPersonGameCameraControllerEnemyTypeBoomOffset> EnemyTypeBoomOffsets { get; set; }

		[FieldOffset(148, 248)]
		public float BoomOffsetInterpRate { get; set; }

		[FieldOffset(152, 252)]
		public float HighBoomLengthOffset { get; set; }

		[FieldOffset(156, 256)]
		public float LowBoomLengthOffset { get; set; }

		[FieldOffset(160, 260)]
		public float DefaultYaw { get; set; }

		[FieldOffset(164, 264)]
		public float MinPitch { get; set; }

		[FieldOffset(168, 268)]
		public float MaxPitch { get; set; }

		[FieldOffset(172, 272)]
		public float PitchRecenteringThreshold { get; set; }

		[FieldOffset(176, 276)]
		public float PitchRecenteringSpeed { get; set; }

		[FieldOffset(180, 280)]
		public float PitchRecenteringFadeInTime { get; set; }

		[FieldOffset(184, 284)]
		public float PitchRecenteringPreDelay { get; set; }

		[FieldOffset(188, 288)]
		public float AutoRotateThreshold { get; set; }

		[FieldOffset(192, 292)]
		public float AutoRotateSpeed { get; set; }

		[FieldOffset(196, 296)]
		public float AutoRotateFadeInTime { get; set; }

		[FieldOffset(200, 300)]
		public float AutoRotatePreDelay { get; set; }

		[FieldOffset(204, 304)]
		public float AutoRotateStraightLineMotionAngleThreshold { get; set; }

		[FieldOffset(208, 308)]
		public float AutoRotateStraightLineMotionTimeThreshold { get; set; }

		[FieldOffset(212, 312)]
		public float TeleportThreshold { get; set; }

		[FieldOffset(216, 316)]
		public float ShotPosInterpRate { get; set; }

		[FieldOffset(220, 320)]
		public float BoomArmInterpRate { get; set; }

		[FieldOffset(224, 324)]
		public float BoomInterpStiffness { get; set; }

		[FieldOffset(228, 328)]
		public float ShotTargetInterpRate { get; set; }

		[FieldOffset(232, 332)]
		public float CameraAnchorInterpRate { get; set; }

		[FieldOffset(236, 336)]
		public float CollisionSmoothRate { get; set; }

		[FieldOffset(240, 340)]
		public float VerticalStiffness { get; set; }

		[FieldOffset(244, 344)]
		public int YawControl { get; set; }

		[FieldOffset(248, 348)]
		public float YawSpeed { get; set; }

		[FieldOffset(252, 352)]
		public int PitchControl { get; set; }

		[FieldOffset(256, 356)]
		public float PitchSpeed { get; set; }

		[FieldOffset(260, 360)]
		public float StickSensitivity { get; set; }

		[FieldOffset(264, 364)]
		public float CameraSpeedAccumulationRate { get; set; }

		[FieldOffset(268, 368)]
		public float MaxAccumulatedTurnSpeed { get; set; }

		[FieldOffset(272, 372)]
		public float MaxBoomRadius { get; set; }

		[FieldOffset(276, 376)]
		public float BoomPitchFactor { get; set; }

		[FieldOffset(280, 380)]
		public float GlobalZoomLevelInterpRate { get; set; }

		[FieldOffset(284, 384)]
		public float GlobalZoomLevelFactor { get; set; }

		[FieldOffset(288, 388)]
		public float CollisionRetargetingStiffness { get; set; }

		[FieldOffset(292, 392)]
		public ExternalObject<CinebotCollisionData> Collision { get; set; }

		[FieldOffset(296, 400)]
		public float SpringStiffness { get; set; }

		[FieldOffset(300, 404)]
		public float SpringFriction { get; set; }

		[FieldOffset(304, 408)]
		public uint HeightAdjustmentBoneHash { get; set; }

		[FieldOffset(308, 412)]
		public bool UseNamedTrackableFacing { get; set; }

		[FieldOffset(309, 413)]
		public bool GlobalZoomLevelEnable { get; set; }

		[FieldOffset(310, 414)]
		public bool EnableCollision { get; set; }

		public ThirdPersonGameCameraControllerData()
		{
			EnemyTypeBoomOffsets = new List<ThirdPersonGameCameraControllerEnemyTypeBoomOffset>();
		}
	}
}
