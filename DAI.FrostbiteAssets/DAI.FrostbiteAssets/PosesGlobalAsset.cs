using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PosesGlobalAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<PoseDefinition>> Poses { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<PoseDefinition> DefaultPose { get; set; }

		public PosesGlobalAsset()
		{
			Poses = new List<ExternalObject<PoseDefinition>>();
		}
	}
}
