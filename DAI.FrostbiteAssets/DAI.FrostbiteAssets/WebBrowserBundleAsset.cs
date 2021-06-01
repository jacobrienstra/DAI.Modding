using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WebBrowserBundleAsset : Asset
	{
		[FieldOffset(12, 72)]
		public string BundlePath { get; set; }

		[FieldOffset(16, 80)]
		public List<string> Fonts { get; set; }

		[FieldOffset(20, 88)]
		public List<Dummy> LocalURLs { get; set; }

		public WebBrowserBundleAsset()
		{
			Fonts = new List<string>();
			LocalURLs = new List<Dummy>();
		}
	}
}
