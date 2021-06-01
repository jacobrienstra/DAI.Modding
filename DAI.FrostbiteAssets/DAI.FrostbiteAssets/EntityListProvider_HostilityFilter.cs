using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityListProvider_HostilityFilter : EntityListProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityListProvider> EntityList { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<PartyLeaderEntityProvider> TeamReferenceEntity { get; set; }

		[FieldOffset(16, 48)]
		public TeamId Team { get; set; }

		[FieldOffset(20, 52)]
		public bool ReturnHostiles { get; set; }
	}
}
