using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RotateToFace_Transform : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<TransformProvider> ReferenceTransform { get; set; }

		[FieldOffset(4, 8)]
		public RotateToFace_TransformType ReferenceTransformType { get; set; }

		[FieldOffset(8, 12)]
		public float RotationOffset { get; set; }
	}
}
