using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ForceMostHatedTarget : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public BWCSMActionTarget MostHated { get; set; }
	}
}
