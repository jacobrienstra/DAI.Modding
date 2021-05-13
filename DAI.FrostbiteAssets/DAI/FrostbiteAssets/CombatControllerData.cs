namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CombatControllerData : ThirdPersonGameCameraControllerData
	{
		[FieldOffset(320, 432)]
		public float PlayerBuffer { get; set; }

		[FieldOffset(324, 436)]
		public float MaxOffsetCorrection { get; set; }

		[FieldOffset(328, 440)]
		public float VelocityFactor { get; set; }

		[FieldOffset(332, 444)]
		public float POIRadius { get; set; }

		[FieldOffset(336, 448)]
		public float POIFullWeightRadius { get; set; }

		[FieldOffset(340, 452)]
		public float FadeInSpeed { get; set; }

		[FieldOffset(344, 456)]
		public float FadeOutSpeed { get; set; }

		[FieldOffset(348, 460)]
		public float HardCone { get; set; }

		[FieldOffset(352, 464)]
		public float HardConeWeightFactor { get; set; }

		[FieldOffset(356, 468)]
		public float SoftCone { get; set; }

		[FieldOffset(360, 472)]
		public float SoftConeWeightFactor { get; set; }

		[FieldOffset(364, 476)]
		public float MaxLagDist { get; set; }

		[FieldOffset(368, 480)]
		public float AnchorUpdateSensitivity { get; set; }

		[FieldOffset(372, 484)]
		public float AnchorDeadzoneRadiusFactor { get; set; }

		[FieldOffset(376, 488)]
		public bool EnableDynamicFraming { get; set; }

		[FieldOffset(377, 489)]
		public bool FactorDistanceIntoWeight { get; set; }

		[FieldOffset(378, 490)]
		public bool FactorAngleIntoWeight { get; set; }

		[FieldOffset(379, 491)]
		public bool LinearFadeOnAngle { get; set; }
	}
}
