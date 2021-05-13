namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CinebotCameraEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public LinearTransform SlaveTransform { get; set; }

		[FieldOffset(144, 240)]
		public Vec3 SlaveAnchorPosition { get; set; }

		[FieldOffset(160, 256)]
		public Vec3 SlaveLookatPosition { get; set; }

		[FieldOffset(176, 272)]
		public Vec3 SlaveFocusPosition { get; set; }

		[FieldOffset(192, 288)]
		public string CinebotCameraName { get; set; }

		[FieldOffset(196, 296)]
		public int Priority { get; set; }

		[FieldOffset(200, 304)]
		public ExternalObject<CinebotCameraData> Camera { get; set; }

		[FieldOffset(204, 312)]
		public float SlaveFov { get; set; }

		[FieldOffset(208, 316)]
		public float SlaveNearPlane { get; set; }

		[FieldOffset(212, 320)]
		public float SlaveFarPlane { get; set; }

		[FieldOffset(216, 324)]
		public float SlaveTimeScale { get; set; }
	}
}
