namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterPaperdollNotificationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int PaperdollType { get; set; }

		[FieldOffset(20, 100)]
		public int Index { get; set; }
	}
}
