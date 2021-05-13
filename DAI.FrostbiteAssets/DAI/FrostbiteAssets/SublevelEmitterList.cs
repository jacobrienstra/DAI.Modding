using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SublevelEmitterList : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint SubLevelHash { get; set; }

		[FieldOffset(4, 8)]
		public List<EmitterPoint> Positions { get; set; }

		public SublevelEmitterList()
		{
			Positions = new List<EmitterPoint>();
		}
	}
}
