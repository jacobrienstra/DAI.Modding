namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PresenceServerBrowserServiceData : PresenceServiceData
	{
		[FieldOffset(12, 72)]
		public MatchmakingCriteria FilterCriterias { get; set; }

		[FieldOffset(52, 152)]
		public uint ListCapacity { get; set; }
	}
}
