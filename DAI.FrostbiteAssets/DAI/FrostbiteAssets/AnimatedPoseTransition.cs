namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AnimatedPoseTransition : PoseTransitionBase
	{
		[FieldOffset(12, 32)]
		public AntRef TransitionAnimation { get; set; }

		[FieldOffset(32, 80)]
		public float AnimationBlendInTime { get; set; }

		[FieldOffset(36, 84)]
		public float AnimationBlendOutTime { get; set; }

		[FieldOffset(40, 88)]
		public float TransitionAnimationDuration { get; set; }
	}
}
