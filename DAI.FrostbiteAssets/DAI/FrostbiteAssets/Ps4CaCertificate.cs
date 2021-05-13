namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps4CaCertificate : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Certificate { get; set; }
	}
}
