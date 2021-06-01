using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWFilterObjectsByTeamEntityData : BWGetObjectsEntityBaseData
	{
		[FieldOffset(20, 104)]
		public TeamId Team { get; set; }

		[FieldOffset(24, 108)]
		public FilterObjectsByTeamComparison Comparison { get; set; }

		[FieldOffset(28, 112)]
		public bool IsTeamSpecific { get; set; }

		[FieldOffset(29, 113)]
		public bool IncludeObjectsWithoutTeam { get; set; }
	}
}
