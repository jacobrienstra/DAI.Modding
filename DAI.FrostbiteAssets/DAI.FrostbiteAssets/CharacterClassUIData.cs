using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterClassUIData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int ClassID { get; set; }

		[FieldOffset(4, 4)]
		public int SubclassID { get; set; }

		[FieldOffset(8, 8)]
		public uint ClassCardIndexInList { get; set; }

		[FieldOffset(12, 16)]
		public string ClassCardName { get; set; }

		[FieldOffset(16, 24)]
		public LocalizedStringReference ClassTitle { get; set; }

		[FieldOffset(20, 48)]
		public LocalizedStringReference ClassDescription { get; set; }

		[FieldOffset(24, 72)]
		public LocalizedStringReference ClassTitleFemale { get; set; }

		[FieldOffset(28, 96)]
		public LocalizedStringReference ClassDescriptionFemale { get; set; }

		[FieldOffset(32, 120)]
		public List<AlternateDescriptionUIData> AlternateDescriptions { get; set; }

		[FieldOffset(36, 128)]
		public List<CharacterClassRaceUIData> ValidRaces { get; set; }

		public CharacterClassUIData()
		{
			AlternateDescriptions = new List<AlternateDescriptionUIData>();
			ValidRaces = new List<CharacterClassRaceUIData>();
		}
	}
}
