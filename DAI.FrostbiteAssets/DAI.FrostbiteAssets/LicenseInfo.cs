namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LicenseInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public bool ClientOnly { get; set; }
	}
}
