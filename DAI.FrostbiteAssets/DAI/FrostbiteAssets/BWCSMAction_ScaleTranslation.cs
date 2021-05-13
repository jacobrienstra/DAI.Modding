namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ScaleTranslation : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<TransformProvider> EndPoint { get; set; }

		[FieldOffset(32, 80)]
		public float FixedDistance { get; set; }

		[FieldOffset(36, 84)]
		public float FarThresholdDistance { get; set; }

		[FieldOffset(40, 88)]
		public float NearThresholdDistance { get; set; }

		[FieldOffset(44, 92)]
		public float MaxDistance { get; set; }

		[FieldOffset(48, 96)]
		public float MinDistance { get; set; }

		[FieldOffset(52, 100)]
		public float AnimationTravelDistance { get; set; }

		[FieldOffset(56, 104)]
		public bool AnimationTravelsBackward { get; set; }
	}
}
