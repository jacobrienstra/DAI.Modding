using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetFacingDirectionMode : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public CreatureFacingDirectionMode Mode { get; set; }

		[FieldOffset(32, 76)]
		public float Priority { get; set; }

		[FieldOffset(36, 80)]
		public float BlendIn { get; set; }

		[FieldOffset(40, 84)]
		public float BlendOut { get; set; }
	}
}
