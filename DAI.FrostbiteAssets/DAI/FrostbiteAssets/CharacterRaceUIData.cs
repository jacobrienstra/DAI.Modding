namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterRaceUIData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int RaceID { get; set; }

		[FieldOffset(4, 8)]
		public string MaleRaceCardName { get; set; }

		[FieldOffset(8, 16)]
		public string FemaleRaceCardName { get; set; }

		[FieldOffset(12, 24)]
		public LocalizedStringReference RaceTitle { get; set; }

		[FieldOffset(16, 48)]
		public LocalizedStringReference RaceDescription { get; set; }

		[FieldOffset(20, 72)]
		public LocalizedStringReference RaceTitleFemale { get; set; }

		[FieldOffset(24, 96)]
		public LocalizedStringReference RaceDescriptionFemale { get; set; }
	}
}
