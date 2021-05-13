namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMenuItem : DataContainer
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference DisplayLabel { get; set; }

		[FieldOffset(12, 48)]
		public LocalizedStringReference Description { get; set; }

		[FieldOffset(16, 72)]
		public string UniqueID { get; set; }

		[FieldOffset(20, 80)]
		public string ItemLinkageId { get; set; }

		[FieldOffset(24, 88)]
		public ExternalObject<TextureAsset> ItemImage { get; set; }

		[FieldOffset(28, 96)]
		public string ItemImageOverridePath { get; set; }

		[FieldOffset(32, 104)]
		public UIDataSourceInfo IsNew { get; set; }

		[FieldOffset(48, 136)]
		public bool Enabled { get; set; }
	}
}
