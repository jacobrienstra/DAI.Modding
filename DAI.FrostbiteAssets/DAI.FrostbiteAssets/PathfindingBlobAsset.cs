using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PathfindingBlobAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<PathfindingBlob> Blobs { get; set; }

		[FieldOffset(16, 80)]
		public List<PathfindingCellInfo> Cells { get; set; }

		public PathfindingBlobAsset()
		{
			Blobs = new List<PathfindingBlob>();
			Cells = new List<PathfindingCellInfo>();
		}
	}
}
