namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DirtySockPresenceBackendData : PresenceBackendData
	{
		[FieldOffset(20, 88)]
		public float FirstPartyConnectionTimeout { get; set; }
	}
}
