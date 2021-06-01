using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LevelStartPoint : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public List<Dummy> AutoloadSublevels { get; set; }

		[FieldOffset(8, 16)]
		public bool IsDefault { get; set; }

		public LevelStartPoint()
		{
			AutoloadSublevels = new List<Dummy>();
		}
	}
}
