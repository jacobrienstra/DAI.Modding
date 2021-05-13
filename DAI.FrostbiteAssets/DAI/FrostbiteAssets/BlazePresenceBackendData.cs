using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlazePresenceBackendData : PresenceBackendData
	{
		[FieldOffset(20, 88)]
		public List<ExternalObject<MatchmakingSession>> MatchmakingSessions { get; set; }

		[FieldOffset(24, 96)]
		public bool UseDemanglerService { get; set; }

		public BlazePresenceBackendData()
		{
			MatchmakingSessions = new List<ExternalObject<MatchmakingSession>>();
		}
	}
}
