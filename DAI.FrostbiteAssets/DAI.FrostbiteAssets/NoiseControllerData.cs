using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class NoiseControllerData : CinebotControllerData
	{
		[FieldOffset(24, 112)]
		public CinebotNoiseParameter Parameter { get; set; }

		[FieldOffset(28, 116)]
		public float Frequency { get; set; }

		[FieldOffset(32, 128)]
		public Vec3 Magnitude { get; set; }

		[FieldOffset(48, 144)]
		public float Roughness { get; set; }

		[FieldOffset(52, 148)]
		public int Octaves { get; set; }

		[FieldOffset(56, 152)]
		public float Delay { get; set; }

		[FieldOffset(60, 156)]
		public float RampIn { get; set; }

		[FieldOffset(64, 160)]
		public float Duration { get; set; }

		[FieldOffset(68, 164)]
		public float RampOut { get; set; }

		[FieldOffset(72, 168)]
		public ExternalObject<Dummy> CurveParams { get; set; }

		[FieldOffset(76, 176)]
		public float CurveDampingTime { get; set; }

		[FieldOffset(80, 180)]
		public CinebotConditionGoesFalseBehavior ConditionGoesFalseBehavior { get; set; }
	}
}
