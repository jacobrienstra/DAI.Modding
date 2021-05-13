using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_CameraState : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<CinebotModeData> Mode { get; set; }

		[FieldOffset(32, 80)]
		public BWCSMActionTarget Trackable { get; set; }

		[FieldOffset(36, 84)]
		public bool ResetTrackable { get; set; }
	}
}
