namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTeleportationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float FadeDuration { get; set; }

		[FieldOffset(20, 100)]
		public int DestinationID { get; set; }

		[FieldOffset(24, 104)]
		public ExternalObject<Dummy> Entities { get; set; }

		[FieldOffset(28, 112)]
		public bool FadeToBlackForPartyTeleports { get; set; }

		[FieldOffset(29, 113)]
		public bool PauseDuringPartyTeleports { get; set; }

		[FieldOffset(30, 114)]
		public bool Enable { get; set; }

		[FieldOffset(31, 115)]
		public bool PortalMode { get; set; }

		[FieldOffset(32, 116)]
		public bool OnlyAI { get; set; }
	}
}
