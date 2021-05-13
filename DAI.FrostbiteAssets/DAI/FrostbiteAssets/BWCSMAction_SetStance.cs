using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetStance : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public BWStance NewStance { get; set; }

		[FieldOffset(32, 76)]
		public bool SetCurrentIdle { get; set; }
	}
}
