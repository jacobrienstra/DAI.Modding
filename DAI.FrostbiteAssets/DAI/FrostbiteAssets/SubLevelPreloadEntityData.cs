using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SubLevelPreloadEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<string> SubLevelsToPreload { get; set; }

		[FieldOffset(24, 112)]
		public bool KeepBundlesLoaded { get; set; }

		public SubLevelPreloadEntityData()
		{
			SubLevelsToPreload = new List<string>();
		}
	}
}
