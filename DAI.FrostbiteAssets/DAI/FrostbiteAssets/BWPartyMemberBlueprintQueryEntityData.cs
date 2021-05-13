using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPartyMemberBlueprintQueryEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public StreamRealm StreamRealm { get; set; }

		[FieldOffset(20, 100)]
		public int PartyMemberID { get; set; }

		[FieldOffset(24, 104)]
		public int ClassID { get; set; }

		[FieldOffset(28, 108)]
		public int RaceID { get; set; }

		[FieldOffset(32, 112)]
		public int GenderID { get; set; }

		[FieldOffset(36, 116)]
		public bool StreamPaperdoll { get; set; }
	}
}
