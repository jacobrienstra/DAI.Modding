namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIModificationCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public string UpFontColorHexString { get; set; }

		[FieldOffset(36, 144)]
		public string DownFontColorHexString { get; set; }

		[FieldOffset(40, 152)]
		public UITextureAtlasTextureReference EmptySlotIcon { get; set; }

		[FieldOffset(60, 192)]
		public int SigilDLCPackage { get; set; }
	}
}
