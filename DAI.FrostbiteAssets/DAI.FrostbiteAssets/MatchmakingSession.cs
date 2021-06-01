using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingSession : DataContainer
	{
		[FieldOffset(8, 24)]
		public MatchmakingSessionMode Mode { get; set; }

		[FieldOffset(12, 28)]
		public uint DurationMs { get; set; }

		[FieldOffset(16, 32)]
		public MatchmakingCriteria Criteria { get; set; }

		[FieldOffset(56, 112)]
		public MatchmakingCreateGameParameters CreateGameParams { get; set; }

		[FieldOffset(80, 152)]
		public ExternalObject<Dummy> OnNotFound { get; set; }

		[FieldOffset(84, 160)]
		public List<ExternalObject<Dummy>> Modifiers { get; set; }

		public MatchmakingSession()
		{
			Modifiers = new List<ExternalObject<Dummy>>();
		}
	}
}
