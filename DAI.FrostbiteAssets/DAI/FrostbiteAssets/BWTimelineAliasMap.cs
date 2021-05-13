using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTimelineAliasMap : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<BWTimelineAliasMap> Parent { get; set; }

		[FieldOffset(16, 80)]
		public List<BWTimelineAliasMapEntry> Index { get; set; }

		public BWTimelineAliasMap()
		{
			Index = new List<BWTimelineAliasMapEntry>();
		}
	}
}
