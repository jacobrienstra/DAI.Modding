using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SubLevelPreloadInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public string SubLevelBundlePath { get; set; }

		[FieldOffset(4, 8)]
		public List<Dummy> PreloadedBlueprintBundles { get; set; }

		public SubLevelPreloadInfo()
		{
			PreloadedBlueprintBundles = new List<Dummy>();
		}
	}
}
