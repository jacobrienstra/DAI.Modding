using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphTargetHeadCharacteristics : LinkObject
	{
		[FieldOffset(0, 0)]
		public BlueprintBundleReference HeadBundle { get; set; }

		[FieldOffset(28, 88)]
		public List<BlueprintBundleReference> HairMeshBundles { get; set; }

		[FieldOffset(32, 96)]
		public List<BlueprintBundleReference> BeardMeshBundles { get; set; }

		[FieldOffset(36, 104)]
		public List<BlueprintBundleReference> HornMeshBundles { get; set; }

		public MorphTargetHeadCharacteristics()
		{
			HairMeshBundles = new List<BlueprintBundleReference>();
			BeardMeshBundles = new List<BlueprintBundleReference>();
			HornMeshBundles = new List<BlueprintBundleReference>();
		}
	}
}
