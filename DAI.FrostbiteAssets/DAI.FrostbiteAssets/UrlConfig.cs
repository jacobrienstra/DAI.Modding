namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UrlConfig : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Environment { get; set; }

		[FieldOffset(4, 8)]
		public string Url { get; set; }
	}
}
