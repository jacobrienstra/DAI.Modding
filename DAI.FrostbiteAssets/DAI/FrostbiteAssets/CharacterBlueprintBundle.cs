namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterBlueprintBundle : LinkObject
	{
		[FieldOffset(0, 0)]
		public int PartyMemberID { get; set; }

		[FieldOffset(4, 4)]
		public int ClassID { get; set; }

		[FieldOffset(8, 8)]
		public int GenderID { get; set; }

		[FieldOffset(12, 12)]
		public int RaceID { get; set; }

		[FieldOffset(16, 16)]
		public uint CharacterBlueprintBundleHash { get; set; }

		[FieldOffset(20, 20)]
		public uint PaperdollBlueprintBundleHash { get; set; }
	}
}
