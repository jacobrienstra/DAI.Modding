using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_CheckAbilityUsageSetting : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(20, 44)]
		public AbilityUsageSetting Usage { get; set; }
	}
}
