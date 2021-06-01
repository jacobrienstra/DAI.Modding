using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_CompareTacticsTargets : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Target1 { get; set; }

		[FieldOffset(20, 44)]
		public TacticsTarget Target2 { get; set; }
	}
}
