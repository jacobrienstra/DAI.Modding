using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3FadeRiftPhase : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<DA3Wave> Waves { get; set; }

		public DA3FadeRiftPhase()
		{
			Waves = new List<DA3Wave>();
		}
	}
}
