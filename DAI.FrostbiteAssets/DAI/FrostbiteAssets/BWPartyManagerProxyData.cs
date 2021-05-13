using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWPartyManagerProxyData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform SpawnPosition { get; set; }

		[FieldOffset(80, 160)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 164)]
		public int PartyMemberID { get; set; }

		[FieldOffset(88, 168)]
		public bool CommitPartyCloseToLeader { get; set; }
	}
}
