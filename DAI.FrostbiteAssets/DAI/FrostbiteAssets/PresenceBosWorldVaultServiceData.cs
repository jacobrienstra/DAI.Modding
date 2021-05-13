namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PresenceBosWorldVaultServiceData : PresenceServiceData
	{
		[FieldOffset(12, 72)]
		public string ReadUrl { get; set; }

		[FieldOffset(16, 80)]
		public string WriteUrl { get; set; }
	}
}
