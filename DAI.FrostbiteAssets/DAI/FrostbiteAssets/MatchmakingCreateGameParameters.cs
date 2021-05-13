using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingCreateGameParameters : LinkObject
	{
		[FieldOffset(0, 0)]
		public MatchmakingNetworkTopology GameTopology { get; set; }

		[FieldOffset(4, 4)]
		public MatchmakingPeer2PeerMode PeerMode { get; set; }

		[FieldOffset(8, 8)]
		public MatchmakingNetworkTopology VoipTopology { get; set; }

		[FieldOffset(12, 16)]
		public List<CoopGameSettings> SettingsByVisibility { get; set; }

		[FieldOffset(16, 24)]
		public List<MatchmakingGameAttribute> Attributes { get; set; }

		[FieldOffset(20, 32)]
		public uint QueueCapacity { get; set; }

		public MatchmakingCreateGameParameters()
		{
			SettingsByVisibility = new List<CoopGameSettings>();
			Attributes = new List<MatchmakingGameAttribute>();
		}
	}
}
