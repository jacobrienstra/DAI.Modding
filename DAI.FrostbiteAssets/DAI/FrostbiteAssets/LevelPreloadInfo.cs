using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LevelPreloadInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<Dummy> PreloadedBlueprintBundles { get; set; }

		[FieldOffset(4, 8)]
		public List<SubLevelPreloadInfo> SubLevelPreloadInfoMap { get; set; }

		public LevelPreloadInfo()
		{
			PreloadedBlueprintBundles = new List<Dummy>();
			SubLevelPreloadInfoMap = new List<SubLevelPreloadInfo>();
		}
	}
}
