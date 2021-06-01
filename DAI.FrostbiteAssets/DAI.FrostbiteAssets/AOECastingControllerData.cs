namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AOECastingControllerData : CinebotControllerData
	{
		[FieldOffset(24, 112)]
		public string SourceAnchorPart { get; set; }

		[FieldOffset(28, 120)]
		public float FOV { get; set; }

		[FieldOffset(32, 128)]
		public Vec3 SourceOffset { get; set; }

		[FieldOffset(48, 144)]
		public Vec3 CollisionOffset { get; set; }

		[FieldOffset(64, 160)]
		public Vec3 TargetOffset { get; set; }

		[FieldOffset(80, 176)]
		public float TargetInterpRate { get; set; }

		[FieldOffset(84, 180)]
		public float PositionInterpRate { get; set; }

		[FieldOffset(88, 184)]
		public float MaxCloseViewRadius { get; set; }

		[FieldOffset(92, 188)]
		public float MinCloseViewRadius { get; set; }

		[FieldOffset(96, 192)]
		public ExternalObject<CinebotCollisionData> Collision { get; set; }

		[FieldOffset(100, 200)]
		public FreeMoveInputData Input { get; set; }

		[FieldOffset(136, 236)]
		public float CentralRadiusMovementAttenuationFactor { get; set; }

		[FieldOffset(140, 240)]
		public float CentralRadiusSize { get; set; }

		[FieldOffset(144, 244)]
		public float TimeToLockMoveDirectionOnCrossover { get; set; }

		[FieldOffset(148, 248)]
		public float RadsPerSecond { get; set; }

		[FieldOffset(152, 252)]
		public bool EnableCollision { get; set; }
	}
}
