namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FreeLookControllerData : CinebotControllerData
	{
		[FieldOffset(24, 112)]
		public CinebotSprungArmData CollisionArm { get; set; }

		[FieldOffset(72, 160)]
		public ExternalObject<TorusTransposerData> TopTransposer { get; set; }

		[FieldOffset(76, 168)]
		public ExternalObject<TorusTransposerData> CenterTransposer { get; set; }

		[FieldOffset(80, 176)]
		public ExternalObject<TorusTransposerData> BottomTransposer { get; set; }

		[FieldOffset(84, 184)]
		public ExternalObject<ScreenSpaceComposerData> TopComposer { get; set; }

		[FieldOffset(88, 192)]
		public ExternalObject<ScreenSpaceComposerData> CenterComposer { get; set; }

		[FieldOffset(92, 200)]
		public ExternalObject<ScreenSpaceComposerData> BottomComposer { get; set; }

		[FieldOffset(96, 208)]
		public float SplineTension { get; set; }

		[FieldOffset(100, 216)]
		public FreeLookData FreeLook { get; set; }

		[FieldOffset(212, 352)]
		public ExternalObject<Dummy> CollisionData { get; set; }

		[FieldOffset(216, 360)]
		public FreeLookCollisionData Collision { get; set; }

		[FieldOffset(232, 376)]
		public bool EnableCollision { get; set; }
	}
}
