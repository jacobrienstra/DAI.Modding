using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWChangeTeamEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public TeamId NewTeamId { get; set; }
	}
}
