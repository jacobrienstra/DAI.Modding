using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentStreamingVolume : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<Vec2> Points { get; set; }

		[FieldOffset(4, 8)]
		public bool IsExclusionVolume { get; set; }

		public ScatterContentStreamingVolume()
		{
			Points = new List<Vec2>();
		}
	}
}
