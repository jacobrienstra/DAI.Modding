using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CharacterPhysicsData : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<CharacterPoseData>> Poses { get; set; }

		[FieldOffset(16, 80)]
		public Vec3 RootOffset { get; set; }

		[FieldOffset(32, 96)]
		public List<ExternalObject<CharacterPoseData>> States { get; set; }

		[FieldOffset(36, 104)]
		public CharacterStateType DefaultState { get; set; }

		[FieldOffset(40, 112)]
		public ExternalObject<CharacterSprintData> Sprint { get; set; }

		[FieldOffset(44, 120)]
		public MaterialDecl MaterialPair { get; set; }

		[FieldOffset(48, 136)]
		public int PushableObjectWeight { get; set; }

		[FieldOffset(52, 140)]
		public float Mass { get; set; }

		[FieldOffset(56, 144)]
		public float MaxAscendAngle { get; set; }

		[FieldOffset(60, 148)]
		public float PhysicalRadius { get; set; }

		[FieldOffset(64, 152)]
		public float LateralRadiusRatio { get; set; }

		[FieldOffset(68, 156)]
		public float EnterSwimStateDepth { get; set; }

		[FieldOffset(72, 160)]
		public float ExitSwimStateDepth { get; set; }

		[FieldOffset(76, 164)]
		public float InputAcceleration { get; set; }

		[FieldOffset(80, 168)]
		public float LadderAcceptAngle { get; set; }

		[FieldOffset(84, 172)]
		public float LadderAcceptAnglePitch { get; set; }

		[FieldOffset(88, 176)]
		public float JumpPenaltyTime { get; set; }

		[FieldOffset(92, 180)]
		public float JumpPenaltyFactor { get; set; }

		[FieldOffset(96, 184)]
		public float RadiusToPredictCollisionOnCharacters { get; set; }

		[FieldOffset(100, 188)]
		public bool AllowPoseChangeDuringTransition { get; set; }

		[FieldOffset(101, 189)]
		public bool AutoPushAwayFromWallsInProne { get; set; }

		[FieldOffset(102, 190)]
		public bool Collides { get; set; }

		public CharacterPhysicsData()
		{
			Poses = new List<ExternalObject<CharacterPoseData>>();
			States = new List<ExternalObject<CharacterPoseData>>();
		}
	}
}
