namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CameraProximityEvaluatorData : EvaluatorData
	{
		[FieldOffset(12, 32)]
		public float ForwardOffset { get; set; }

		[FieldOffset(16, 48)]
		public Vec3 Size { get; set; }

		[FieldOffset(32, 64)]
		public Vec3 Offset { get; set; }

		[FieldOffset(48, 80)]
		public Vec3 InnerRadiusDirection { get; set; }

		[FieldOffset(64, 96)]
		public float InnerRadius { get; set; }
	}
}
