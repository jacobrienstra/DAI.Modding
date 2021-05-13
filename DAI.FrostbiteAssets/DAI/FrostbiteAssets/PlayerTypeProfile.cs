namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlayerTypeProfile : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<DA3PersistenceData> Values { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<AwardDataTree> Awards { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<Dummy> RankParams { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<Dummy> Scoring { get; set; }

		[FieldOffset(28, 104)]
		public EloParameters EloParams { get; set; }

		[FieldOffset(48, 144)]
		public ExternalObject<Dummy> StaticUnlocks { get; set; }

		[FieldOffset(52, 152)]
		public ExternalObject<Dummy> SpamSettings { get; set; }
	}
}
