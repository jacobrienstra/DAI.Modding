using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatCurveEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public float In { get; set; }

		[FieldOffset(24, 104)]
		public AudioCurve Curve { get; set; }

		[FieldOffset(32, 120)]
		public bool OutputIntegral { get; set; }
	}
}
