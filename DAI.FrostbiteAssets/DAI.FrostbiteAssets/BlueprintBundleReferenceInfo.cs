using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlueprintBundleReferenceInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public uint BundleHash { get; set; }

		[FieldOffset(8, 12)]
		public BundleHeapInfo Heap { get; set; }

		[FieldOffset(20, 24)]
		public BundleSettingsInfo BundleSettingsInfo { get; set; }

		[FieldOffset(28, 40)]
		public List<uint> ParentSharedBundleHashes { get; set; }

		public BlueprintBundleReferenceInfo()
		{
			ParentSharedBundleHashes = new List<uint>();
		}
	}
}
