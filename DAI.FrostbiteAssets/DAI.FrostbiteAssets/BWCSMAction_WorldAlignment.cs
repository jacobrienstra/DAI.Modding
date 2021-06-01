using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_WorldAlignment : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public int SourceBoneId { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<TransformProvider> WorldAlignTransform { get; set; }

		[FieldOffset(36, 88)]
		public float RotationOffset { get; set; }

		[FieldOffset(40, 92)]
		public WorldAlignmentBlendType BlendType { get; set; }

		[FieldOffset(44, 96)]
		public bool Enable90DegreeOffsetHack { get; set; }

		[FieldOffset(45, 97)]
		public bool BlendOut { get; set; }
	}
}
