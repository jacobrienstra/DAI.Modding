using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_HasThreat : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget HaterEntity { get; set; }

		[FieldOffset(20, 44)]
		public TacticsTarget HatedEntity { get; set; }

		[FieldOffset(24, 48)]
		public bool CheckMostHated { get; set; }
	}
}
