namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlueprintBundleSettings : LinkObject
	{
		[FieldOffset(0, 0)]
		public BundleHeapInfo Heap { get; set; }

		[FieldOffset(12, 16)]
		public BundleSettingsInfo BundleSettingsInfo { get; set; }
	}
}
