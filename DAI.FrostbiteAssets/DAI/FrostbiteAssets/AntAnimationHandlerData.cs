using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntAnimationHandlerData : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntAnimatableData Animatable { get; set; }

		[FieldOffset(104, 248)]
		public AntRef RootController { get; set; }

		[FieldOffset(124, 296)]
		public LodBinding LodBinding { get; set; }

		[FieldOffset(224, 536)]
		public AnimationControlBinding AnimationControlBinding { get; set; }

		[FieldOffset(244, 584)]
		public float LodDistanceScale { get; set; }

		[FieldOffset(248, 592)]
		public List<int> JointOutputFieldHashes { get; set; }

		[FieldOffset(252, 600)]
		public List<int> JointEnabledFieldHashes { get; set; }

		[FieldOffset(256, 608)]
		public AntControllerComplexity ControllerComplexity { get; set; }

		[FieldOffset(260, 612)]
		public bool ReportBackFromAnt { get; set; }

		[FieldOffset(261, 613)]
		public bool EnableMasterSlaveCopy { get; set; }

		[FieldOffset(262, 614)]
		public bool IsProp { get; set; }

		public AntAnimationHandlerData()
		{
			JointOutputFieldHashes = new List<int>();
			JointEnabledFieldHashes = new List<int>();
		}
	}
}
