namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class XenonPresenceBackendData : PresenceBackendData
	{
		[FieldOffset(20, 88)]
		public uint TitleId { get; set; }
	}
}
