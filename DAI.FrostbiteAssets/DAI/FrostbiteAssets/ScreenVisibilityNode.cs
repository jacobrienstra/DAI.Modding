using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScreenVisibilityNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public ExternalObject<UINodePort> Out { get; set; }

		[FieldOffset(28, 80)]
		public List<ContainedGuid> ScreenPartitionGuids { get; set; }

		[FieldOffset(32, 88)]
		public bool Visible { get; set; }

		[FieldOffset(33, 89)]
		public bool AllScreens { get; set; }

		public ScreenVisibilityNode()
		{
			ScreenPartitionGuids = new List<ContainedGuid>();
		}
	}
}
