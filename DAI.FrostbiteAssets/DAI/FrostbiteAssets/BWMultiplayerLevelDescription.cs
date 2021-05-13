namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMultiplayerLevelDescription : LevelDescriptionComponent
	{
		[FieldOffset(8, 24)]
		public int BlazeMapId { get; set; }

		[FieldOffset(12, 28)]
		public int RouteId { get; set; }

		[FieldOffset(16, 32)]
		public LocalizedStringReference DisplayableName { get; set; }

		[FieldOffset(20, 56)]
		public LocalizedStringReference DisplayableDescription { get; set; }

		[FieldOffset(24, 80)]
		public ExternalObject<TextureAsset> levelSplashTexture { get; set; }

		[FieldOffset(28, 88)]
		public bool ShowInLobby { get; set; }
	}
}
