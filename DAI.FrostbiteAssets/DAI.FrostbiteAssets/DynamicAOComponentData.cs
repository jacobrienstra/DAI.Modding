using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DynamicAOComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Realm Realm { get; set; }

		[FieldOffset(116, 196)]
		public float SsaoFade { get; set; }

		[FieldOffset(120, 200)]
		public float SsaoRadius { get; set; }

		[FieldOffset(124, 204)]
		public float SsaoMaxDistanceInner { get; set; }

		[FieldOffset(128, 208)]
		public float SsaoMaxDistanceOuter { get; set; }

		[FieldOffset(132, 212)]
		public float HbaoRadius { get; set; }

		[FieldOffset(136, 216)]
		public float HbaoAngleBias { get; set; }

		[FieldOffset(140, 220)]
		public float HbaoAttenuation { get; set; }

		[FieldOffset(144, 224)]
		public float HbaoContrast { get; set; }

		[FieldOffset(148, 228)]
		public float HbaoMaxFootprintRadius { get; set; }

		[FieldOffset(152, 232)]
		public float HbaoPowerExponent { get; set; }

		[FieldOffset(156, 236)]
		public bool Enable { get; set; }
	}
}
