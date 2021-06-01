using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LanguageBundlesListEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public LanguageFormat Language { get; set; }

		[FieldOffset(4, 8)]
		public List<string> BundlePaths { get; set; }

		public LanguageBundlesListEntry()
		{
			BundlePaths = new List<string>();
		}
	}
}
