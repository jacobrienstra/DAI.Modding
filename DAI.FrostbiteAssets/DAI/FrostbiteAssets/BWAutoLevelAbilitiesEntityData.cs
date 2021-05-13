using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAutoLevelAbilitiesEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public int MaxAbilities { get; set; }

		[FieldOffset(24, 108)]
		public AbilityAutoMapping Mapping { get; set; }

		[FieldOffset(28, 112)]
		public bool ConsumeAbilityPoints { get; set; }
	}
}
