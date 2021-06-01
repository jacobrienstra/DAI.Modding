namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PhysicsDrivenAnimationEntityBinding : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef PhysicsMotionTarget { get; set; }

		[FieldOffset(20, 48)]
		public AntRef AimLeftRight { get; set; }

		[FieldOffset(40, 96)]
		public AntRef AimUpDown { get; set; }

		[FieldOffset(60, 144)]
		public AntRef Crouch { get; set; }

		[FieldOffset(80, 192)]
		public AntRef ForceSetTrajectory { get; set; }

		[FieldOffset(100, 240)]
		public AntRef InAir { get; set; }

		[FieldOffset(120, 288)]
		public AntRef Skydive { get; set; }

		[FieldOffset(140, 336)]
		public AntRef Swim { get; set; }

		[FieldOffset(160, 384)]
		public AntRef InputBackward { get; set; }

		[FieldOffset(180, 432)]
		public AntRef InputForward { get; set; }

		[FieldOffset(200, 480)]
		public AntRef InputLeft { get; set; }

		[FieldOffset(220, 528)]
		public AntRef InputRight { get; set; }

		[FieldOffset(240, 576)]
		public AntRef IsEnemy { get; set; }

		[FieldOffset(260, 624)]
		public AntRef Jump { get; set; }

		[FieldOffset(280, 672)]
		public AntRef LeanLeftRight { get; set; }

		[FieldOffset(300, 720)]
		public AntRef Prone { get; set; }

		[FieldOffset(320, 768)]
		public AntRef Sprint { get; set; }

		[FieldOffset(340, 816)]
		public AntRef GroundSupported { get; set; }

		[FieldOffset(360, 864)]
		public AntRef GroundNormal { get; set; }

		[FieldOffset(380, 912)]
		public AntRef GroundDistance { get; set; }

		[FieldOffset(400, 960)]
		public AntRef GroundAngleZ { get; set; }

		[FieldOffset(420, 1008)]
		public AntRef GroundAngleX { get; set; }

		[FieldOffset(440, 1056)]
		public AntRef GroundAngleFromNormal { get; set; }

		[FieldOffset(460, 1104)]
		public AntRef IsClientAnimatable { get; set; }

		[FieldOffset(480, 1152)]
		public AntRef CustomizationScreen { get; set; }

		[FieldOffset(500, 1200)]
		public AntRef Minimal3pServer { get; set; }

		[FieldOffset(520, 1248)]
		public AntRef VerticalImpact { get; set; }

		[FieldOffset(540, 1296)]
		public AntRef VerticalImpactSpeed { get; set; }

		[FieldOffset(560, 1344)]
		public AntRef FalseSignal { get; set; }

		[FieldOffset(580, 1392)]
		public AntRef LockArmsToCameraWeight { get; set; }

		[FieldOffset(600, 1440)]
		public AntRef WindDirection { get; set; }

		[FieldOffset(620, 1488)]
		public AntRef WindStrength { get; set; }

		[FieldOffset(640, 1536)]
		public AntRef WaterDepth { get; set; }

		[FieldOffset(660, 1584)]
		public AntRef EyeWaterDepth { get; set; }
	}
}
