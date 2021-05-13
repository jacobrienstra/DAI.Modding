using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GroundHeightData : LinkObject
	{
		[FieldOffset(0, 0)]
		public float WorldSize { get; set; }

		[FieldOffset(4, 4)]
		public Vec2 HeightSpan { get; set; }

		[FieldOffset(12, 16)]
		public List<short> Data { get; set; }

		public GroundHeightData()
		{
			Data = new List<short>();
		}
	}
}
