namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WebBrowserSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public string ApplicationName { get; set; }

		[FieldOffset(20, 48)]
		public string UserAgent { get; set; }

		[FieldOffset(24, 56)]
		public string StandardFont { get; set; }

		[FieldOffset(28, 64)]
		public string SerifFont { get; set; }

		[FieldOffset(32, 72)]
		public string SansSerifFont { get; set; }

		[FieldOffset(36, 80)]
		public string MonospaceFont { get; set; }

		[FieldOffset(40, 88)]
		public string CursiveFont { get; set; }

		[FieldOffset(44, 96)]
		public string FantasyFont { get; set; }

		[FieldOffset(48, 104)]
		public string SystemFont { get; set; }

		[FieldOffset(52, 112)]
		public string DefaultCSS { get; set; }

		[FieldOffset(56, 120)]
		public ExternalObject<WebBrowserBundleAsset> WebBrowserBundle { get; set; }

		[FieldOffset(60, 128)]
		public bool SystemFontBold { get; set; }
	}
}
