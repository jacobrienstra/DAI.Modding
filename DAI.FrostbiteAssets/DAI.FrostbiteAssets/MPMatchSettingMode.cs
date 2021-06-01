namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPMatchSettingMode : DataContainer
	{
		[FieldOffset(8, 24)]
		public int ModeId { get; set; }

		[FieldOffset(12, 32)]
		public LocalizedStringReference DisplayName { get; set; }

		[FieldOffset(16, 56)]
		public LocalizedStringReference Description { get; set; }

		[FieldOffset(20, 80)]
		public UITextureAtlasTextureReference ModeIcon { get; set; }
	}
}
