namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CinebotCameraProxyData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public LinearTransform SlaveTransform { get; set; }

		[FieldOffset(176, 272)]
		public LinearTransform SlaveTransformOrigin { get; set; }

		[FieldOffset(240, 336)]
		public Vec3 SlaveAnchorPosition { get; set; }

		[FieldOffset(256, 352)]
		public Vec3 SlaveLookatPosition { get; set; }

		[FieldOffset(272, 368)]
		public Vec3 SlaveFocusPosition { get; set; }

		[FieldOffset(288, 384)]
		public ExternalObject<CinebotModeData> Mode { get; set; }

		[FieldOffset(292, 392)]
		public float PriorityOverride { get; set; }

		[FieldOffset(296, 396)]
		public float SlaveFov { get; set; }

		[FieldOffset(300, 400)]
		public float SlaveNearPlane { get; set; }

		[FieldOffset(304, 404)]
		public float SlaveFarPlane { get; set; }

		[FieldOffset(308, 408)]
		public float SlaveTimeScale { get; set; }

		[FieldOffset(312, 412)]
		public bool EnablePriorityOverride { get; set; }

		[FieldOffset(313, 413)]
		public bool ReverseCamera { get; set; }
	}
}
