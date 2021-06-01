using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureClassEnumTranslator : Asset
	{
		[FieldOffset(12, 72)]
		public List<CreatureClassEnumTranslatorEntry> Data { get; set; }

		public CreatureClassEnumTranslator()
		{
			Data = new List<CreatureClassEnumTranslatorEntry>();
		}
	}
}
