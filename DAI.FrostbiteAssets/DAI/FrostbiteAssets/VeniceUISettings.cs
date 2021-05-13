namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VeniceUISettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public string MetaDataAssetPath { get; set; }

		[FieldOffset(20, 48)]
		public string TransitionEffectPath { get; set; }

		[FieldOffset(24, 56)]
		public string ServerBannerTexturePath { get; set; }

		[FieldOffset(28, 64)]
		public string GradientTexturePath { get; set; }

		[FieldOffset(32, 72)]
		public bool GetStatsInOnlineFlow { get; set; }
	}
}
