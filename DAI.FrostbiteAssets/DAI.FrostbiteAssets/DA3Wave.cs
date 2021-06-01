using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3Wave : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<DA3WaveCreature> Creatures { get; set; }

		public DA3Wave()
		{
			Creatures = new List<DA3WaveCreature>();
		}
	}
}
