using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundEmitterBehaviorData : SoundBehaviorData
	{
		[FieldOffset(8, 24)]
		public float FadeWidth { get; set; }

		[FieldOffset(12, 28)]
		public FadeCurveType FadeCurve { get; set; }

		[FieldOffset(16, 32)]
		public QualityScalableInt NumberOfEmitters { get; set; }

		[FieldOffset(32, 48)]
		public ExternalObject<SoundPatchConfigurationAsset> Sound { get; set; }
	}
}
