using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StaticModelNetworkInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<IndexRange> PartNetworkIdRanges { get; set; }

		[FieldOffset(4, 8)]
		public uint NetworkIdCount { get; set; }

		[FieldOffset(8, 16)]
		public List<ChildStaticModelNetworkInfo> ChildNetworkInfos { get; set; }

		[FieldOffset(12, 24)]
		public uint ChildNetworkIdCount { get; set; }

		public StaticModelNetworkInfo()
		{
			PartNetworkIdRanges = new List<IndexRange>();
			ChildNetworkInfos = new List<ChildStaticModelNetworkInfo>();
		}
	}
}
