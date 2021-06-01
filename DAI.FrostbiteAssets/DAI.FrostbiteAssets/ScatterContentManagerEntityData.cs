using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ScatterContentCategoryInfo> CategoryInfo { get; set; }

		[FieldOffset(20, 104)]
		public ScatterContentTuning Tuning { get; set; }

		[FieldOffset(72, 156)]
		public float LowCpuThreshold { get; set; }

		[FieldOffset(76, 160)]
		public float MediumCpuThreshold { get; set; }

		public ScatterContentManagerEntityData()
		{
			CategoryInfo = new List<ScatterContentCategoryInfo>();
		}
	}
}
