using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBundlesAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<UIBundleAssetState> UIBundleAssetStateList { get; set; }

		[FieldOffset(16, 80)]
		public List<FontCollectionLookupEntry> FontCollectionLookups { get; set; }

		[FieldOffset(20, 88)]
		public string RootMovieClipPath { get; set; }

		public UIBundlesAsset()
		{
			UIBundleAssetStateList = new List<UIBundleAssetState>();
			FontCollectionLookups = new List<FontCollectionLookupEntry>();
		}
	}
}
