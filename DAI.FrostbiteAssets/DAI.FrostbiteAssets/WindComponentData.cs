using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class WindComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Realm Realm { get; set; }

		[FieldOffset(116, 196)]
		public float WindDirection { get; set; }

		[FieldOffset(120, 200)]
		public float WindStrength { get; set; }

		[FieldOffset(124, 204)]
		public float WindVariationMultiplier { get; set; }

		[FieldOffset(128, 208)]
		public float WindVariationRateMultiplier { get; set; }

		[FieldOffset(132, 212)]
		public float WindMicroVariationMultiplier { get; set; }

		[FieldOffset(136, 216)]
		public float TurbulenceMultiplier { get; set; }

		[FieldOffset(140, 220)]
		public float TurbulenceScale { get; set; }
	}
}
