using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public UISystemType System { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<UIBundlesAsset> Bundles { get; set; }

		[FieldOffset(24, 56)]
		public ExternalObject<ProfileOptionsAsset> ProfileOptions { get; set; }

		[FieldOffset(28, 64)]
		public LanguageFormat Language { get; set; }

		[FieldOffset(32, 68)]
		public bool OneBundlePerGraph { get; set; }

		[FieldOffset(33, 69)]
		public bool DrawEnable { get; set; }

		[FieldOffset(34, 70)]
		public bool VideoBufferingEnable { get; set; }

		[FieldOffset(35, 71)]
		public bool EnableJobs { get; set; }

		[FieldOffset(36, 72)]
		public bool RunUpdateInRender { get; set; }

		[FieldOffset(37, 73)]
		public bool RunUIFirstInRender { get; set; }
	}
}
