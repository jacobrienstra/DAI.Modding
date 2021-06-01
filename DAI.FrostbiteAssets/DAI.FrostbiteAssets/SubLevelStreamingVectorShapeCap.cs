using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SubLevelStreamingVectorShapeCap : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<Vec3> Vertices { get; set; }

		[FieldOffset(4, 8)]
		public List<uint> Indices { get; set; }

		public SubLevelStreamingVectorShapeCap()
		{
			Vertices = new List<Vec3>();
			Indices = new List<uint>();
		}
	}
}
