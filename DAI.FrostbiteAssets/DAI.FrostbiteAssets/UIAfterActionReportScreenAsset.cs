namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIAfterActionReportScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public UITextureAtlasTextureReference GoldIcon { get; set; }

		[FieldOffset(88, 232)]
		public UITextureAtlasTextureReference InfluenceIcon { get; set; }

		[FieldOffset(108, 272)]
		public UITextureAtlasTextureReference NewOperationIcon { get; set; }
	}
}
