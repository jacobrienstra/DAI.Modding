namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterSummaryUIData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int GenderID { get; set; }

		[FieldOffset(4, 4)]
		public int RaceID { get; set; }

		[FieldOffset(8, 8)]
		public int ClassID { get; set; }

		[FieldOffset(12, 12)]
		public int SubclassID { get; set; }

		[FieldOffset(16, 16)]
		public ExternalObject<TextureAsset> RaceCard { get; set; }

		[FieldOffset(20, 24)]
		public ExternalObject<TextureAsset> ClassCard { get; set; }

		[FieldOffset(24, 32)]
		public ExternalObject<TextureAsset> BackgroundCard { get; set; }

		[FieldOffset(28, 40)]
		public LocalizedStringReference BackgroundTitle { get; set; }

		[FieldOffset(32, 64)]
		public LocalizedStringReference BackgroundBody { get; set; }

		[FieldOffset(36, 88)]
		public string RaceCardName { get; set; }

		[FieldOffset(40, 96)]
		public string ClassCardName { get; set; }

		[FieldOffset(44, 104)]
		public string BackgroundCardName { get; set; }
	}
}
