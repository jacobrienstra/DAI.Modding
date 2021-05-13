namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMultiplayerFrameTopBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference LocalizedGoldString { get; set; }

		[FieldOffset(12, 48)]
		public LocalizedStringReference LocalizedPlatinumString { get; set; }

		[FieldOffset(16, 72)]
		public LocalizedStringReference LocalizedTitleString { get; set; }

		[FieldOffset(20, 96)]
		public LocalizedStringReference LocalizedTab1Title { get; set; }

		[FieldOffset(24, 120)]
		public LocalizedStringReference LocalizedTab2Title { get; set; }

		[FieldOffset(28, 144)]
		public LocalizedStringReference LocalizedTab3Title { get; set; }

		[FieldOffset(32, 168)]
		public LocalizedStringReference LocalizedTab4Title { get; set; }

		[FieldOffset(36, 192)]
		public UIDataSourceInfo Tab1Star { get; set; }

		[FieldOffset(52, 224)]
		public UIDataSourceInfo Tab2Star { get; set; }

		[FieldOffset(68, 256)]
		public UIDataSourceInfo Tab3Star { get; set; }

		[FieldOffset(84, 288)]
		public UIDataSourceInfo Tab4Star { get; set; }

		[FieldOffset(100, 320)]
		public UIDataSourceInfo CurrentGoldAmount { get; set; }

		[FieldOffset(116, 352)]
		public UIDataSourceInfo CurrentPlatinumAmount { get; set; }

		[FieldOffset(132, 384)]
		public UIDataSourceInfo CurrentTab { get; set; }

		[FieldOffset(148, 416)]
		public UIDataSourceInfo PlayerGamertag { get; set; }

		[FieldOffset(164, 448)]
		public UIDataSourceInfo PrestigeScore { get; set; }

		[FieldOffset(180, 480)]
		public UIDataSourceInfo EyeMode { get; set; }

		[FieldOffset(196, 512)]
		public UIDataSourceInfo PlatinumEnabled { get; set; }

		[FieldOffset(212, 544)]
		public ExternalObject<TextureAsset> EyeTexture { get; set; }
	}
}
