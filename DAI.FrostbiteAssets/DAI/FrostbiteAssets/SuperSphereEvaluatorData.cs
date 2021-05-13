namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SuperSphereEvaluatorData : EvaluatorData
	{
		[FieldOffset(12, 32)]
		public float InnerRadius { get; set; }

		[FieldOffset(16, 48)]
		public Vec3 Scale { get; set; }

		[FieldOffset(32, 64)]
		public Vec3 Pivot { get; set; }

		[FieldOffset(48, 80)]
		public float OuterRadius { get; set; }

		[FieldOffset(52, 84)]
		public float StartZenithAngle { get; set; }

		[FieldOffset(56, 88)]
		public float EndZenithAngle { get; set; }

		[FieldOffset(60, 92)]
		public float InnerRadiusBound { get; set; }

		[FieldOffset(64, 96)]
		public float StartZenithAngleBound { get; set; }

		[FieldOffset(68, 100)]
		public float EndZenithAngleBound { get; set; }

		[FieldOffset(72, 104)]
		public float StartAzimuthAngle { get; set; }

		[FieldOffset(76, 108)]
		public float EndAzimuthAngle { get; set; }

		[FieldOffset(80, 112)]
		public float DistributionAlongRadius { get; set; }

		[FieldOffset(84, 116)]
		public bool OrientAlongZ { get; set; }
	}
}
