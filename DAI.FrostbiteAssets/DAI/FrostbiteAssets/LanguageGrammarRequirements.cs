using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LanguageGrammarRequirements : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<LanguageNounGender> NounGenders { get; set; }

		[FieldOffset(4, 8)]
		public List<LanguageNounNumber> NounNumbers { get; set; }

		[FieldOffset(8, 16)]
		public CapitalizationStyle Capitalization { get; set; }

		[FieldOffset(12, 20)]
		public bool InitialVowelDeclinesPreviousModifier { get; set; }

		public LanguageGrammarRequirements()
		{
			NounGenders = new List<LanguageNounGender>();
			NounNumbers = new List<LanguageNounNumber>();
		}
	}
}
