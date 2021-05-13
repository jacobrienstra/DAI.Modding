using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AntAnimatableComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public Realm Realm { get; set; }

		[FieldOffset(100, 180)]
		public SubRealm SubRealm { get; set; }

		[FieldOffset(104, 184)]
		public AntAnimationHandlerData AnimationData { get; set; }

		[FieldOffset(368, 800)]
		public List<AntAnimatableComponentMeshData> MeshDatas { get; set; }

		[FieldOffset(372, 808)]
		public JointOutputModeEnum JointOutputMode { get; set; }

		[FieldOffset(376, 812)]
		public bool AutoActivate { get; set; }

		[FieldOffset(377, 813)]
		public bool AnimationControlledFromStart { get; set; }

		[FieldOffset(378, 814)]
		public bool ForceDisableCulling { get; set; }

		public AntAnimatableComponentData()
		{
			MeshDatas = new List<AntAnimatableComponentMeshData>();
		}
	}
}
