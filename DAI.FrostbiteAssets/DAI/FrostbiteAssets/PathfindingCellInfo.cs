using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PathfindingCellInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public AxisAlignedBox Bounds { get; set; }

		[FieldOffset(32, 32)]
		public List<PathfindingBlob> Blobs { get; set; }

		public PathfindingCellInfo()
		{
			Blobs = new List<PathfindingBlob>();
		}
	}
}
