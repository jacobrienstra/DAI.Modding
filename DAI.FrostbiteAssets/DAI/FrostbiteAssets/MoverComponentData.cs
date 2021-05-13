using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class MoverComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public EntityMoverType type { get; set; }

		[FieldOffset(100, 184)]
		public ExternalObject<MoverTune> moverTune { get; set; }

		[FieldOffset(104, 192)]
		public float goalPlanFailureTreshold { get; set; }

		[FieldOffset(108, 196)]
		public float goalHeightFailureTreshold { get; set; }

		[FieldOffset(112, 200)]
		public ExternalObject<RadiusData> radiusData { get; set; }

		[FieldOffset(116, 208)]
		public float MoveSpeedModifier { get; set; }

		[FieldOffset(120, 216)]
		public AntRef DesiredMovementAngleGameState { get; set; }

		[FieldOffset(140, 264)]
		public AntRef DesiredRelativeMovementAngleGameState { get; set; }

		[FieldOffset(160, 312)]
		public AntRef DesiredMovementSpeedGameState { get; set; }

		[FieldOffset(180, 360)]
		public AntRef DesiredFacingAngleGameState { get; set; }

		[FieldOffset(200, 408)]
		public AntRef DesiredRelativeFacingAngleGameState { get; set; }

		[FieldOffset(220, 456)]
		public AntRef IsTurningInPlaceGameState { get; set; }

		[FieldOffset(240, 504)]
		public AntRef DistanceToGoalGameState { get; set; }

		[FieldOffset(260, 552)]
		public float MinMoveStickMagnitude { get; set; }

		[FieldOffset(264, 556)]
		public float WalkingDistance { get; set; }

		[FieldOffset(268, 560)]
		public float WalkingStickMagnitude { get; set; }

		[FieldOffset(272, 564)]
		public bool EnablePuppetMode { get; set; }

		[FieldOffset(273, 565)]
		public bool EnableClientMotionMode { get; set; }

		[FieldOffset(274, 566)]
		public bool LockToNavGraph { get; set; }

		[FieldOffset(275, 567)]
		public bool SimulateMovementAsInput { get; set; }

		[FieldOffset(276, 568)]
		public bool ReplicateDesiredMovement { get; set; }

		[FieldOffset(277, 569)]
		public bool ReplicatePathSpec { get; set; }
	}
}
