using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class ZoneStreamerInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public long GridResource { get; set; }

		[FieldOffset(8, 8)]
		public string SubLevelPath { get; set; }

		[FieldOffset(12, 16)]
		public List<ZoneStreamerZoneInfo> ZoneInfos { get; set; }

		[FieldOffset(16, 24)]
		public List<ushort> BundleParents { get; set; }

		[FieldOffset(20, 32)]
		public List<string> BundleNames { get; set; }

		[FieldOffset(24, 40)]
		public List<Vec4> RegionColours { get; set; }

		public ZoneStreamerInfo()
		{
			ZoneInfos = new List<ZoneStreamerZoneInfo>();
			BundleParents = new List<ushort>();
			BundleNames = new List<string>();
			RegionColours = new List<Vec4>();
		}
	}
}
