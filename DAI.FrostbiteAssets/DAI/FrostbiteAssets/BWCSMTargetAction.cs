using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMTargetAction : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public BWCSMActionTarget Target { get; set; }
	}
}
