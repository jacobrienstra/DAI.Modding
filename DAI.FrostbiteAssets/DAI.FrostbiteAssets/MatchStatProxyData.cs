namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchStatProxyData : EntityData
	{
		[FieldOffset(16, 96)]
		public string StatItem { get; set; }

		[FieldOffset(20, 104)]
		public int StatValue { get; set; }
	}
}
