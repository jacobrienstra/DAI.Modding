using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PoseTransitionTime
	{
		[FieldOffset(0, 0)]
		public CharacterPoseType ToPose { get; set; }

		[FieldOffset(4, 4)]
		public float TransitionTime { get; set; }
	}
}
