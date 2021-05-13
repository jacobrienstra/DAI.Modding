namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAnimationControlledComponentBinding : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef AnimationControlled { get; set; }

		[FieldOffset(20, 48)]
		public AntRef CannedAnimation { get; set; }

		[FieldOffset(40, 96)]
		public AntRef DesiredMovementDirection { get; set; }

		[FieldOffset(60, 144)]
		public AntRef EnableAntCollisionTest { get; set; }

		[FieldOffset(80, 192)]
		public AntRef EnableSliding { get; set; }

		[FieldOffset(100, 240)]
		public AntRef PrimaryCollisionPlaneNormal { get; set; }

		[FieldOffset(120, 288)]
		public AntRef PrimaryCollisionPlanePoint { get; set; }

		[FieldOffset(140, 336)]
		public AntRef EnableSecondaryCollisionPlane { get; set; }

		[FieldOffset(160, 384)]
		public AntRef SecondaryCollisionPlaneNormal { get; set; }

		[FieldOffset(180, 432)]
		public AntRef SecondaryCollisionPlanePoint { get; set; }

		[FieldOffset(200, 480)]
		public AntRef TrajectoryAnimationScale { get; set; }

		[FieldOffset(220, 528)]
		public AntRef AnimationDrivesPhysicsInternal { get; set; }

		[FieldOffset(240, 576)]
		public AntRef AnimationDrivesPhysics { get; set; }

		[FieldOffset(260, 624)]
		public AntRef EnableSetPositionRigOp { get; set; }

		[FieldOffset(280, 672)]
		public AntRef DisableAnimationDrivenCollision { get; set; }
	}
}
