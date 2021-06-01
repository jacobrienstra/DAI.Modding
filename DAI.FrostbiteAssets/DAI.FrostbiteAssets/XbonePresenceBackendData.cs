namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class XbonePresenceBackendData : PresenceBackendData
	{
		[FieldOffset(20, 88)]
		public uint TitleId { get; set; }

		[FieldOffset(24, 96)]
		public string ServiceConfigId { get; set; }
	}
}
