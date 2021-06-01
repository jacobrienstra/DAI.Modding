using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCheckCreatureHealthData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int PartyMemberToCheck { get; set; }

		[FieldOffset(24, 104)]
		public BWCheckCreatureHealthCompare BWComparisonType { get; set; }

		[FieldOffset(28, 108)]
		public float HeathToCheck { get; set; }

		[FieldOffset(32, 112)]
		public ExternalObject<Dummy> InputCreatures { get; set; }
	}
}
