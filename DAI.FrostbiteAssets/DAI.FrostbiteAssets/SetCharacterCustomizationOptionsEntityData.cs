namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SetCharacterCustomizationOptionsEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int CharacterClassID { get; set; }

		[FieldOffset(20, 100)]
		public int CharacterSubclassID { get; set; }

		[FieldOffset(24, 104)]
		public int CharacterBackgroundID { get; set; }

		[FieldOffset(28, 108)]
		public int CharacterGenderID { get; set; }

		[FieldOffset(32, 112)]
		public int CharacterRaceID { get; set; }

		[FieldOffset(36, 116)]
		public int DifficultyModeID { get; set; }

		[FieldOffset(40, 120)]
		public string CharacterName { get; set; }
	}
}
