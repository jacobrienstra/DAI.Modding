using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LevelReportingAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<LevelDescriptionAsset>> BuiltLevels { get; set; }

		public LevelReportingAsset()
		{
			BuiltLevels = new List<ExternalObject<LevelDescriptionAsset>>();
		}
	}
}
