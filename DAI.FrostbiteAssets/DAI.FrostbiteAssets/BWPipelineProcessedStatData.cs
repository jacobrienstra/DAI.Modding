using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPipelineProcessedStatData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWModifiableStat> Stat { get; set; }

		[FieldOffset(4, 8)]
		public List<uint> DependentsBitSet { get; set; }

		public BWPipelineProcessedStatData()
		{
			DependentsBitSet = new List<uint>();
		}
	}
}
