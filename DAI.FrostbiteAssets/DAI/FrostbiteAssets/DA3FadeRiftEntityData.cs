using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3FadeRiftEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<DA3FadeRiftPhase> Phases { get; set; }

		public DA3FadeRiftEntityData()
		{
			Phases = new List<DA3FadeRiftPhase>();
		}
	}
}
