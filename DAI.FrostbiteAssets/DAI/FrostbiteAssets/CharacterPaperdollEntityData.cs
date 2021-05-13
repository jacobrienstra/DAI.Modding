using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterPaperdollEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<BWIntegralStat> RaceStat { get; set; }

		[FieldOffset(20, 104)]
		public PaperdollType PaperdollType { get; set; }

		[FieldOffset(24, 108)]
		public int SpawnerCount { get; set; }
	}
}
