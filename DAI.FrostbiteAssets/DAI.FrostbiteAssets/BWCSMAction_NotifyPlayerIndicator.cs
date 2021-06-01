using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_NotifyPlayerIndicator : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public PlayerIndicatorNotificationType Notification { get; set; }

		[FieldOffset(32, 76)]
		public bool NewValue { get; set; }

		[FieldOffset(33, 77)]
		public bool ResetOnInactive { get; set; }
	}
}
