namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SharedBundleReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public BundleHeapInfo Heap { get; set; }
	}
}
