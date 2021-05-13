namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlendedPoseTransition : PoseTransitionBase
	{
		[FieldOffset(12, 32)]
		public float BlendTime { get; set; }
	}
}
