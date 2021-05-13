using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FontCollectionLookupEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public string CollectionBasePath { get; set; }

		[FieldOffset(4, 8)]
		public LanguageFormat Language { get; set; }

		[FieldOffset(8, 12)]
		public bool HasCompleteCharset { get; set; }
	}
}
