namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ShelfNotificationConfigData : LinkObject
	{
		[FieldOffset(0, 0)]
		public string IDName { get; set; }

		[FieldOffset(4, 8)]
		public UITextureAtlasTextureReference Icon { get; set; }

		[FieldOffset(24, 48)]
		public int SoundID { get; set; }
	}
}
