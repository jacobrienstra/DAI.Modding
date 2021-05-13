using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundAreaEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<SoundPatchConfigurationAsset> Sound { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<BigWorldSettingsAsset> BigWorld { get; set; }

		[FieldOffset(24, 112)]
		public float FadeWidth { get; set; }

		[FieldOffset(28, 116)]
		public float ProximityMultiplier { get; set; }

		[FieldOffset(32, 120)]
		public FadeCurveType FadeCurve { get; set; }

		[FieldOffset(36, 124)]
		public bool EnableOnCreation { get; set; }
	}
}
