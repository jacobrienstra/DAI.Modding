using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3QPEWaveEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int Wave { get; set; }

		[FieldOffset(20, 104)]
		public List<DA3Wave> Waves { get; set; }

		public DA3QPEWaveEntityData()
		{
			Waves = new List<DA3Wave>();
		}
	}
}
