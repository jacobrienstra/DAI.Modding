namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UberNotificationConfigData : LinkObject
	{
		[FieldOffset(0, 0)]
		public string IDName { get; set; }

		[FieldOffset(4, 8)]
		public UITextureAtlasTextureReference Icon { get; set; }

		[FieldOffset(24, 48)]
		public UITextureAtlasTextureReference Background { get; set; }

		[FieldOffset(44, 88)]
		public int SoundID { get; set; }
	}
}
