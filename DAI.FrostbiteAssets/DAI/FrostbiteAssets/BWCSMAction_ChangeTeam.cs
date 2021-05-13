using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ChangeTeam : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public TeamId TeamId { get; set; }

		[FieldOffset(32, 76)]
		public bool RemoveAtEnd { get; set; }
	}
}
