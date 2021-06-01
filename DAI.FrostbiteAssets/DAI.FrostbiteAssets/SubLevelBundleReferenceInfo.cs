using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SubLevelBundleReferenceInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public uint BundleHash { get; set; }

		[FieldOffset(8, 12)]
		public BundleHeapInfo Heap { get; set; }

		[FieldOffset(20, 24)]
		public uint ParentSubLevelBundleHash { get; set; }

		[FieldOffset(24, 32)]
		public List<uint> PreloadedBlueprintBundleHashes { get; set; }

		public SubLevelBundleReferenceInfo()
		{
			PreloadedBlueprintBundleHashes = new List<uint>();
		}
	}
}
