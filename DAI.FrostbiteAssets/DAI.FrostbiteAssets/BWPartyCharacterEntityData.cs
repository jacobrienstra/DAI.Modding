using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPartyCharacterEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int PartyMemberID { get; set; }
	}
}
