using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWStatList : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<BWStat>> Stats { get; set; }

		[FieldOffset(16, 80)]
		public List<BWPipelineProcessedStatData> PipelineProcessedStatData { get; set; }

		public BWStatList()
		{
			Stats = new List<ExternalObject<BWStat>>();
			PipelineProcessedStatData = new List<BWPipelineProcessedStatData>();
		}
	}
}
