using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CharacterPoseData : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<Vec2> ThrottleModifierCurve { get; set; }

		[FieldOffset(12, 32)]
		public float StepHeight { get; set; }

		[FieldOffset(16, 48)]
		public Vec3 EyePosition { get; set; }

		[FieldOffset(32, 64)]
		public Vec3 CollisionBoxMinExpand { get; set; }

		[FieldOffset(48, 80)]
		public Vec3 CollisionBoxMaxExpand { get; set; }

		[FieldOffset(64, 96)]
		public float Height { get; set; }

		[FieldOffset(68, 104)]
		public List<PoseTransitionTime> TransitionTimes { get; set; }

		[FieldOffset(72, 112)]
		public LookConstraintsData LookConstraints { get; set; }

		[FieldOffset(88, 128)]
		public CharacterPoseType PoseType { get; set; }

		[FieldOffset(92, 132)]
		public CharacterPoseCollisionType CollisionType { get; set; }

		public CharacterPoseData()
		{
			ThrottleModifierCurve = new List<Vec2>();
			TransitionTimes = new List<PoseTransitionTime>();
		}
	}
}
