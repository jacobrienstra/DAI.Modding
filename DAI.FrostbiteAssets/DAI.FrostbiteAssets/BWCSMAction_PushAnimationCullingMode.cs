using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_PushAnimationCullingMode : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public AnimationCullingType Mode { get; set; }

		[FieldOffset(32, 76)]
		public int Priority { get; set; }
	}
}
