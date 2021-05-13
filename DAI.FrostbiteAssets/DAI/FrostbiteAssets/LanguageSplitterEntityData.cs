using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LanguageSplitterEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LanguageSplitterSystemToCheck SystemToCheck { get; set; }

		[FieldOffset(20, 104)]
		public List<LanguageFormat> LanguageOutputs { get; set; }

		public LanguageSplitterEntityData()
		{
			LanguageOutputs = new List<LanguageFormat>();
		}
	}
}
