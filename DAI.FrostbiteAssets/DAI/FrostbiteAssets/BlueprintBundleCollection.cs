using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlueprintBundleCollection : Asset
	{
		[FieldOffset(12, 72)]
		public List<BlueprintBundleReference> Bundles { get; set; }

		public BlueprintBundleCollection()
		{
			Bundles = new List<BlueprintBundleReference>();
		}
	}
}
