namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ScreenSpaceComposerData : CinebotComposerData
	{
		[FieldOffset(40, 128)]
		public string TargetPart { get; set; }

		[FieldOffset(44, 136)]
		public ExternalObject<CinebotLocatorIdentifierAsset> CinebotLocatorIdentifier { get; set; }

		[FieldOffset(48, 144)]
		public ScreenSpaceComposerTarget Secondary { get; set; }

		[FieldOffset(80, 192)]
		public Vec3 Offset { get; set; }

		[FieldOffset(96, 208)]
		public ExternalObject<Dummy> OffsetScale { get; set; }

		[FieldOffset(100, 216)]
		public float HardTop { get; set; }

		[FieldOffset(104, 220)]
		public float SoftTop { get; set; }

		[FieldOffset(108, 224)]
		public float SoftBottom { get; set; }

		[FieldOffset(112, 228)]
		public float HardBottom { get; set; }

		[FieldOffset(116, 232)]
		public float VerticalBlendTime { get; set; }

		[FieldOffset(120, 236)]
		public ScreenSpaceComposerBlendControl VerticalBlendControl { get; set; }

		[FieldOffset(144, 260)]
		public float HardLeft { get; set; }

		[FieldOffset(148, 264)]
		public float SoftLeft { get; set; }

		[FieldOffset(152, 268)]
		public float SoftRight { get; set; }

		[FieldOffset(156, 272)]
		public float HardRight { get; set; }

		[FieldOffset(160, 276)]
		public float HorizontalBlendTime { get; set; }

		[FieldOffset(164, 280)]
		public ScreenSpaceComposerBlendControl HorizontalBlendControl { get; set; }

		[FieldOffset(188, 304)]
		public float FOV { get; set; }

		[FieldOffset(192, 308)]
		public float Roll { get; set; }

		[FieldOffset(196, 312)]
		public float NearPlane { get; set; }

		[FieldOffset(200, 316)]
		public float FarPlane { get; set; }

		[FieldOffset(204, 320)]
		public float UpDampingBlendTime { get; set; }

		[FieldOffset(208, 324)]
		public bool UseUpFromScene { get; set; }

		[FieldOffset(209, 325)]
		public bool UseUpDamping { get; set; }
	}
}
