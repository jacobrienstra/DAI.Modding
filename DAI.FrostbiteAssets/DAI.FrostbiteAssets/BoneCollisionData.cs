using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BoneCollisionData : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec4 DebugDrawColor { get; set; }

		[FieldOffset(16, 16)]
		public Vec3 CapsuleOffset { get; set; }

		[FieldOffset(32, 32)]
		public PitchModifier MaxPitch { get; set; }

		[FieldOffset(64, 64)]
		public PitchModifier MinPitch { get; set; }

		[FieldOffset(96, 96)]
		public string BoneName { get; set; }

		[FieldOffset(100, 104)]
		public HitReactionType AnimationHitReactionType { get; set; }

		[FieldOffset(104, 112)]
		public MaterialDecl MaterialPair { get; set; }

		[FieldOffset(108, 128)]
		public int BoneAxis { get; set; }

		[FieldOffset(112, 132)]
		public float CapsuleLength { get; set; }

		[FieldOffset(116, 136)]
		public float CapsuleRadius { get; set; }

		[FieldOffset(120, 144)]
		public ExternalObject<Dummy> AimAssistTarget { get; set; }

		[FieldOffset(124, 152)]
		public bool ValidInHiLod { get; set; }

		[FieldOffset(125, 153)]
		public bool ValidInLowLod { get; set; }

		[FieldOffset(126, 154)]
		public bool DeactivateIfBehindWall { get; set; }

		[FieldOffset(127, 155)]
		public bool UsePhysicsRotation { get; set; }
	}
}
