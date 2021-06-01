namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SharedBundleReferenceInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public uint BundleHash { get; set; }

		[FieldOffset(8, 12)]
		public BundleHeapInfo Heap { get; set; }
	}
}
