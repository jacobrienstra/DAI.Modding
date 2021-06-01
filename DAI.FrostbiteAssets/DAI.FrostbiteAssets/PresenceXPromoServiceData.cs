namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PresenceXPromoServiceData : PresenceServiceData
	{
		[FieldOffset(12, 72)]
		public string ClientId { get; set; }
	}
}
