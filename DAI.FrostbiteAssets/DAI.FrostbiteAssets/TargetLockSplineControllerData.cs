namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TargetLockSplineControllerData : ThirdPersonGameCameraControllerData
	{
		[FieldOffset(320, 432)]
		public TargetLockSplineControllerSourceOffset SourceOffset { get; set; }

		[FieldOffset(368, 480)]
		public Vec3 TargetOffset { get; set; }

		[FieldOffset(384, 496)]
		public Vec3 WorldSpaceTargetOffset { get; set; }

		[FieldOffset(400, 512)]
		public string SourceAnchorPart { get; set; }

		[FieldOffset(404, 520)]
		public float MinOffsetDist { get; set; }

		[FieldOffset(408, 524)]
		public float DeadZoneRadiusFactor { get; set; }

		[FieldOffset(412, 528)]
		public float TargetSwitchInterpTime { get; set; }

		[FieldOffset(416, 532)]
		public float TargetSpeedStiffnessDecay { get; set; }

		[FieldOffset(420, 536)]
		public float TargetSpeedFactor { get; set; }

		[FieldOffset(424, 540)]
		public float TargetStiffness { get; set; }

		[FieldOffset(428, 544)]
		public float TargetDeadZoneCenterFactor { get; set; }

		[FieldOffset(432, 548)]
		public float TargetDeadZoneDotFactor { get; set; }
	}
}
