using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ModelAnimationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform AnimationEntitySpace { get; set; }

		[FieldOffset(80, 160)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 168)]
		public string DefaultAnimation { get; set; }

		[FieldOffset(88, 176)]
		public int AnimationIndex { get; set; }

		[FieldOffset(92, 184)]
		public ExternalObject<AntAnimationSetAsset> AnimationSet { get; set; }

		[FieldOffset(96, 192)]
		public float ExternalTime { get; set; }

		[FieldOffset(100, 196)]
		public float PlaybackSpeed { get; set; }

		[FieldOffset(104, 200)]
		public int InstanceSeed { get; set; }

		[FieldOffset(108, 204)]
		public GameplayBones BoneToPlace { get; set; }

		[FieldOffset(112, 208)]
		public ModelAnimationTransformType ModelAnimationTransformType { get; set; }

		[FieldOffset(116, 212)]
		public ModelAnimationUpdateOrder JointWorldTransformUpdateOrder { get; set; }

		[FieldOffset(120, 216)]
		public List<Dummy> JointOutputFieldHashes { get; set; }

		[FieldOffset(124, 224)]
		public bool AutoStart { get; set; }

		[FieldOffset(125, 225)]
		public bool Looping { get; set; }

		[FieldOffset(126, 226)]
		public bool ResetAfterStop { get; set; }

		[FieldOffset(127, 227)]
		public bool PlayFirstFrame { get; set; }

		[FieldOffset(128, 228)]
		public bool AnimationEntitySpaceActive { get; set; }

		[FieldOffset(129, 229)]
		public bool DisableCulling { get; set; }

		[FieldOffset(130, 230)]
		public bool EnableJointWorldTransformOutput { get; set; }

		[FieldOffset(131, 231)]
		public bool ShowDebugTransforms { get; set; }

		public ModelAnimationEntityData()
		{
			JointOutputFieldHashes = new List<Dummy>();
		}
	}
}
