using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCreateObjectListData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int PartyMemberID1 { get; set; }

		[FieldOffset(24, 104)]
		public int PartyMemberID2 { get; set; }

		[FieldOffset(28, 108)]
		public int PartyMemberID3 { get; set; }

		[FieldOffset(32, 112)]
		public int PartyMemberID4 { get; set; }
	}
}
