namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TorusTransposerData : CinebotTransposerData
	{
		[FieldOffset(28, 120)]
		public string AnchorPart { get; set; }

		[FieldOffset(32, 128)]
		public Vec3 Offset { get; set; }

		[FieldOffset(48, 144)]
		public Vec3 OffsetDampTime { get; set; }

		[FieldOffset(64, 160)]
		public ExternalObject<Dummy> OffsetScale { get; set; }

		[FieldOffset(68, 168)]
		public float InnerRadiusHard { get; set; }

		[FieldOffset(72, 172)]
		public float InnerRadiusSoft { get; set; }

		[FieldOffset(76, 176)]
		public float OuterRadiusSoft { get; set; }

		[FieldOffset(80, 180)]
		public float OuterRadiusHard { get; set; }

		[FieldOffset(84, 184)]
		public float RadiusBlendTime { get; set; }

		[FieldOffset(88, 188)]
		public float UpperHeightHard { get; set; }

		[FieldOffset(92, 192)]
		public float UpperHeightSoft { get; set; }

		[FieldOffset(96, 196)]
		public float LowerHeightSoft { get; set; }

		[FieldOffset(100, 200)]
		public float LowerHeightHard { get; set; }

		[FieldOffset(104, 204)]
		public float HeightBlendTime { get; set; }

		[FieldOffset(108, 208)]
		public float SimpleHeadingOffset { get; set; }

		[FieldOffset(112, 212)]
		public float LowerHeadingHard { get; set; }

		[FieldOffset(116, 216)]
		public float LowerHeadingSoft { get; set; }

		[FieldOffset(120, 220)]
		public float UpperHeadingSoft { get; set; }

		[FieldOffset(124, 224)]
		public float UpperHeadingHard { get; set; }

		[FieldOffset(128, 228)]
		public float HeadingBlendTime { get; set; }

		[FieldOffset(132, 232)]
		public ExternalObject<Dummy> HeadingBlendTimeCurve { get; set; }

		[FieldOffset(136, 240)]
		public float WorldHeading { get; set; }

		[FieldOffset(140, 244)]
		public float VelocityBasedDirectionOffset { get; set; }

		[FieldOffset(144, 248)]
		public string TargetOverride { get; set; }

		[FieldOffset(148, 256)]
		public string TargetOverridePart { get; set; }

		[FieldOffset(152, 264)]
		public ExternalObject<FollowRotation> Rotation { get; set; }

		[FieldOffset(156, 272)]
		public bool UseSimpleHeadingDamping { get; set; }

		[FieldOffset(157, 273)]
		public bool UseWorldHeading { get; set; }

		[FieldOffset(158, 274)]
		public bool UseVelocityBasedDirection { get; set; }

		[FieldOffset(159, 275)]
		public bool UseFilteredVelocityBasedDirection { get; set; }

		[FieldOffset(160, 276)]
		public bool MakeVelocityBasedDirectionHorizontal { get; set; }

		[FieldOffset(161, 277)]
		public bool CacheFirstFrameHeading { get; set; }

		[FieldOffset(162, 278)]
		public bool FollowTarget { get; set; }
	}
}
