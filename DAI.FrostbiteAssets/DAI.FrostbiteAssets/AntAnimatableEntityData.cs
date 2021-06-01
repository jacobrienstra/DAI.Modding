using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntAnimatableEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public SubRealm SubRealm { get; set; }

		[FieldOffset(24, 104)]
		public AntAnimationHandlerData AnimationData { get; set; }

		[FieldOffset(288, 720)]
		public AnimationControlModeEnum InitialAnimationControlMode { get; set; }

		[FieldOffset(292, 724)]
		public JointOutputModeEnum JointOutputMode { get; set; }

		[FieldOffset(296, 728)]
		public List<Dummy> JointOutputPropertyIds { get; set; }

		[FieldOffset(300, 736)]
		public bool AutoActivate { get; set; }

		[FieldOffset(301, 737)]
		public bool InitialForceDisableCulling { get; set; }

		[FieldOffset(302, 738)]
		public bool DisableAutoDistanceCulling { get; set; }

		[FieldOffset(303, 739)]
		public bool Interpolation { get; set; }

		public AntAnimatableEntityData()
		{
			JointOutputPropertyIds = new List<Dummy>();
		}
	}
}
