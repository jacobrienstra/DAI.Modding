namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OriginPresenceBackendData : PresenceBackendData
	{
		[FieldOffset(20, 88)]
		public string ContentId { get; set; }

		[FieldOffset(24, 96)]
		public string Title { get; set; }

		[FieldOffset(28, 104)]
		public string MultiplayerId { get; set; }

		[FieldOffset(32, 112)]
		public string TitleSecret { get; set; }
	}
}
