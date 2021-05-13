using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotTransitionData : CinebotBlendData
	{
		[FieldOffset(24, 40)]
		public CinebotBlendType Blend { get; set; }

		[FieldOffset(28, 44)]
		public CinebotTransitionType TransitionType { get; set; }

		[FieldOffset(32, 48)]
		public bool Clean { get; set; }
	}
}
