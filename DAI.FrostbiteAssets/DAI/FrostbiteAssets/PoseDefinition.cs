using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PoseDefinition : DataContainer
	{
		[FieldOffset(8, 24)]
		public AntRef Animation { get; set; }

		[FieldOffset(28, 72)]
		public float AnimationDuration { get; set; }

		[FieldOffset(32, 80)]
		public List<ExternalObject<PoseDefinition>> Transitions { get; set; }

		public PoseDefinition()
		{
			Transitions = new List<ExternalObject<PoseDefinition>>();
		}
	}
}
