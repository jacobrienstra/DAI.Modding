using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BundleHeapInfo
	{
		[FieldOffset(0, 0)]
		public BundleHeapType HeapType { get; set; }

		[FieldOffset(4, 4)]
		public uint InitialSize { get; set; }

		[FieldOffset(8, 8)]
		public bool AllowGrow { get; set; }
	}
}
