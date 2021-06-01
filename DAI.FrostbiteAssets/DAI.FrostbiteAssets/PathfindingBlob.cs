using System;
using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PathfindingBlob : LinkObject
	{
		[FieldOffset(0, 0)]
		public Guid BlobId { get; set; }

		[FieldOffset(16, 16)]
		public uint BlobSize { get; set; }

		[FieldOffset(20, 24)]
		public List<uint> ChunkSizes { get; set; }

		public PathfindingBlob()
		{
			ChunkSizes = new List<uint>();
		}
	}
}
