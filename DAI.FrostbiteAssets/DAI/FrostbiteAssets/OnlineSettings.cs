using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OnlineSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public List<OnlinePlatformConfiguration> Platforms { get; set; }

		[FieldOffset(20, 48)]
		public BackendType Backend { get; set; }

		[FieldOffset(24, 52)]
		public BackendType PeerBackend { get; set; }

		[FieldOffset(28, 56)]
		public OnlineEnvironment Environment { get; set; }

		[FieldOffset(32, 60)]
		public int QueueCapacityOverride { get; set; }

		[FieldOffset(36, 64)]
		public ExternalObject<OnlineProviderAsset> Provider { get; set; }

		[FieldOffset(40, 72)]
		public string ServiceNameOverride { get; set; }

		[FieldOffset(44, 80)]
		public int BlazeLogLevel { get; set; }

		[FieldOffset(48, 84)]
		public int DirtySockLogLevel { get; set; }

		[FieldOffset(52, 88)]
		public ExternalObject<Dummy> RichPresence { get; set; }

		[FieldOffset(56, 96)]
		public ExternalObject<LicenseConfiguration> LicenseConfig { get; set; }

		[FieldOffset(60, 104)]
		public string MatchmakingOptions { get; set; }

		[FieldOffset(64, 112)]
		public string MatchmakingMode { get; set; }

		[FieldOffset(68, 120)]
		public string Region { get; set; }

		[FieldOffset(72, 128)]
		public string Country { get; set; }

		[FieldOffset(76, 136)]
		public string MatchmakingToken { get; set; }

		[FieldOffset(80, 144)]
		public uint NegativeUserCacheRefreshPeriod { get; set; }

		[FieldOffset(84, 152)]
		public string ClientGameConfigurationOverride { get; set; }

		[FieldOffset(88, 160)]
		public List<ExternalObject<Dummy>> EntitlementQueries { get; set; }

		[FieldOffset(92, 168)]
		public uint PingPeriod { get; set; }

		[FieldOffset(96, 172)]
		public uint WebFeedUnreadCountFetchPeriod { get; set; }

		[FieldOffset(100, 176)]
		public uint WebFeedMaxFetchAttempts { get; set; }

		[FieldOffset(104, 180)]
		public uint WebFeedMaxItems { get; set; }

		[FieldOffset(108, 184)]
		public uint WebFeedMinimumMillisecondsBetweenRequests { get; set; }

		[FieldOffset(112, 188)]
		public uint WebFeedMillisecondsBetweenNewRequestAttempt { get; set; }

		[FieldOffset(116, 192)]
		public string WebFeedUrlPrefix { get; set; }

		[FieldOffset(120, 200)]
		public string WebFeedCountUrlPrefix { get; set; }

		[FieldOffset(124, 208)]
		public bool ClientIsPresenceEnabled { get; set; }

		[FieldOffset(125, 209)]
		public bool ServerIsPresenceEnabled { get; set; }

		[FieldOffset(126, 210)]
		public bool UseExternalLoginFlow { get; set; }

		[FieldOffset(127, 211)]
		public bool IsSecure { get; set; }

		[FieldOffset(128, 212)]
		public bool EnableQoS { get; set; }

		[FieldOffset(129, 213)]
		public bool MatchmakeImmediately { get; set; }

		[FieldOffset(130, 214)]
		public bool ServerIsReconfigurable { get; set; }

		[FieldOffset(131, 215)]
		public bool SupportHostMigration { get; set; }

		[FieldOffset(132, 216)]
		public bool UseFallback { get; set; }

		public OnlineSettings()
		{
			Platforms = new List<OnlinePlatformConfiguration>();
			EntitlementQueries = new List<ExternalObject<Dummy>>();
		}
	}
}
