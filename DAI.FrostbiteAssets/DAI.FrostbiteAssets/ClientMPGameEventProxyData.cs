namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClientMPGameEventProxyData : EntityData
	{
		[FieldOffset(16, 96)]
		public float FloatyDelay { get; set; }
	}
}
