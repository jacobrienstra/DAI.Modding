namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ServerMPCheckpointEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int StartPointID { get; set; }

		[FieldOffset(20, 100)]
		public int FactionID { get; set; }

		[FieldOffset(24, 104)]
		public int RouteID { get; set; }

		[FieldOffset(28, 108)]
		public int EventID { get; set; }

		[FieldOffset(32, 112)]
		public int SpecialistID { get; set; }

		[FieldOffset(36, 116)]
		public int WaveID { get; set; }

		[FieldOffset(40, 120)]
		public int WildernessID { get; set; }

		[FieldOffset(44, 124)]
		public int DragonID { get; set; }

		[FieldOffset(48, 128)]
		public bool DragonSummoned { get; set; }
	}
}
