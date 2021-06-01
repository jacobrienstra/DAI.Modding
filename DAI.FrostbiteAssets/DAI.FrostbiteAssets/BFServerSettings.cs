using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BFServerSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public string ForceTeamForPlayerTag { get; set; }

		[FieldOffset(20, 48)]
		public int ForceTeamForPlayerTagTeam { get; set; }

		[FieldOffset(24, 52)]
		public float NoInteractivityTimeoutTime { get; set; }

		[FieldOffset(28, 56)]
		public float NoInteractivityThresholdLimit { get; set; }

		[FieldOffset(32, 60)]
		public uint NoInteractivityBanRoundCount { get; set; }

		[FieldOffset(36, 64)]
		public string BannerUrl { get; set; }

		[FieldOffset(40, 72)]
		public string ServerPreset { get; set; }

		[FieldOffset(44, 80)]
		public string ServerDescription { get; set; }

		[FieldOffset(48, 88)]
		public string ServerMessage { get; set; }

		[FieldOffset(52, 96)]
		public string ServerAdministrationSettings { get; set; }

		[FieldOffset(56, 104)]
		public string ServerAdministrationMapRotation { get; set; }

		[FieldOffset(60, 112)]
		public uint ServerAdministrationRoundsPerMap { get; set; }

		[FieldOffset(64, 116)]
		public uint TeamSwitchImbalanceLimit { get; set; }

		[FieldOffset(68, 120)]
		public uint GameSize { get; set; }

		[FieldOffset(72, 128)]
		public string PingSite { get; set; }

		[FieldOffset(76, 136)]
		public string GameMod { get; set; }

		[FieldOffset(80, 144)]
		public VoiceChannel DefaultVoiceChannel { get; set; }

		[FieldOffset(84, 148)]
		public int DeathmatchFriendZoneFallbackCount { get; set; }

		[FieldOffset(88, 152)]
		public bool AutoBalance { get; set; }

		[FieldOffset(89, 153)]
		public bool OverrideAutoBalance { get; set; }

		[FieldOffset(90, 154)]
		public bool IsManDownRotationEnabled { get; set; }

		[FieldOffset(91, 155)]
		public bool IsKillerCameraEnabled { get; set; }

		[FieldOffset(92, 156)]
		public bool MapSequencerEnabled { get; set; }
	}
}
