namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(1)]
	public class ItemPartyMemberAppearanceIDStruct
	{
		[FieldOffset(0, 0)]
		public sbyte PartyMemberID { get; set; }

		[FieldOffset(1, 1)]
		public sbyte Gender { get; set; }

		[FieldOffset(2, 2)]
		public sbyte PartyMemberClassTypeID { get; set; }

		[FieldOffset(3, 3)]
		public sbyte ItemRaceID { get; set; }
	}
}
