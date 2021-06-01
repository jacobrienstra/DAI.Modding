namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ServerMPGameEventProxyData : EntityData
	{
		[FieldOffset(16, 96)]
		public int ObjectiveTitleStringId { get; set; }

		[FieldOffset(20, 100)]
		public int ObjectiveDescriptionStringId { get; set; }

		[FieldOffset(24, 104)]
		public int StartPointId { get; set; }
	}
}
