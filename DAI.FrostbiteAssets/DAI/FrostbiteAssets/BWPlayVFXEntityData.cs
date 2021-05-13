namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWPlayVFXEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 PositionOffset { get; set; }

		[FieldOffset(32, 112)]
		public Vec3 Orientation { get; set; }

		[FieldOffset(48, 128)]
		public LinearTransform SourceTransform { get; set; }

		[FieldOffset(112, 192)]
		public LinearTransform TargetTransform { get; set; }

		[FieldOffset(176, 256)]
		public LinearTransform OtherTransform { get; set; }

		[FieldOffset(240, 320)]
		public ExternalObject<BWVisualEffectEntityData> VisualEffectData { get; set; }

		[FieldOffset(244, 328)]
		public int AttachToId { get; set; }

		[FieldOffset(248, 332)]
		public float Scale { get; set; }

		[FieldOffset(252, 336)]
		public int SourceBoneId { get; set; }

		[FieldOffset(256, 340)]
		public int TargetBoneId { get; set; }

		[FieldOffset(260, 344)]
		public int OtherBoneId { get; set; }

		[FieldOffset(264, 348)]
		public bool StayAttached { get; set; }

		[FieldOffset(265, 349)]
		public bool UseImpactPoint { get; set; }

		[FieldOffset(266, 350)]
		public bool PreserveEffectOrientation { get; set; }

		[FieldOffset(267, 351)]
		public bool OffsetFromCharacterForward { get; set; }
	}
}
