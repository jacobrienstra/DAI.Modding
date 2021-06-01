using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ZoneStreamerZoneInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<ushort> Neighbours { get; set; }

		public ZoneStreamerZoneInfo()
		{
			Neighbours = new List<ushort>();
		}
	}
}
