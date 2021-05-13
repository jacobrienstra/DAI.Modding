using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LocatorHubEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<SoundPatchConfigurationAsset> Sound { get; set; }

		[FieldOffset(20, 104)]
		public float FadeWidth { get; set; }

		[FieldOffset(24, 108)]
		public float ProximityMultiplier { get; set; }

		[FieldOffset(28, 112)]
		public FadeCurveType FadeCurve { get; set; }

		[FieldOffset(32, 116)]
		public bool FacePlayerEnabled { get; set; }
	}
}
