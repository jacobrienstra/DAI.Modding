using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PopulationControllerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<RuntimeRegion> Regions { get; set; }

		[FieldOffset(20, 104)]
		public bool Debug { get; set; }

		[FieldOffset(21, 105)]
		public bool TrueRandom { get; set; }

		public PopulationControllerEntityData()
		{
			Regions = new List<RuntimeRegion>();
		}
	}
}
