using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TeamFilterEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public TeamId Team { get; set; }

		[FieldOffset(24, 104)]
		public bool InvertFilter { get; set; }

		[FieldOffset(25, 105)]
		public bool GenerateEventForEveryMatchingTeamMember { get; set; }
	}
}
