namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(1)]
	public class MatchmakingGameSettings
	{
		[FieldOffset(0, 0)]
		public bool OpenToBrowsing { get; set; }

		[FieldOffset(1, 1)]
		public bool OpenToInvites { get; set; }

		[FieldOffset(2, 2)]
		public bool OpenToMatchmaking { get; set; }

		[FieldOffset(3, 3)]
		public bool OpenToJoinByPlayer { get; set; }

		[FieldOffset(4, 4)]
		public bool HostMigratable { get; set; }

		[FieldOffset(5, 5)]
		public bool Ranked { get; set; }

		[FieldOffset(6, 6)]
		public bool AdminOnlyInvites { get; set; }

		[FieldOffset(7, 7)]
		public bool EnforceSingleGroupJoin { get; set; }

		[FieldOffset(8, 8)]
		public bool JoinInProgressSupported { get; set; }

		[FieldOffset(9, 9)]
		public bool AdminInvitesOnlyIgnoreEntryChecks { get; set; }

		[FieldOffset(10, 10)]
		public bool EnablePersistedGameId { get; set; }

		[FieldOffset(11, 11)]
		public bool AllowSameTeamId { get; set; }

		[FieldOffset(12, 12)]
		public bool DisconnectReservation { get; set; }

		[FieldOffset(13, 13)]
		public bool DynamicReputationRequirement { get; set; }
	}
}
