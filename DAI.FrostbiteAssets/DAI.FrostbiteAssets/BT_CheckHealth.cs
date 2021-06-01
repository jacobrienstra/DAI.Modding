using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_CheckHealth : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(20, 44)]
		public ECompare Comparator { get; set; }

		[FieldOffset(24, 48)]
		public float Value { get; set; }
	}
}
