namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RotateVectorData : EvaluatorData
	{
		[FieldOffset(12, 32)]
		public float Angle { get; set; }

		[FieldOffset(16, 36)]
		public bool InputAffectsPhi { get; set; }

		[FieldOffset(17, 37)]
		public bool RotateWithinPlane { get; set; }
	}
}
