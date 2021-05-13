namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BundleSettingsInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint GroupIdentifier { get; set; }

		[FieldOffset(4, 8)]
		public string GroupName { get; set; }
	}
}
