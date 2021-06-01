using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_CheckStat : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(20, 44)]
		public ECompare Comparator { get; set; }

		[FieldOffset(24, 48)]
		public ExternalObject<BWStat> Stat { get; set; }

		[FieldOffset(28, 56)]
		public float Value { get; set; }

		[FieldOffset(32, 60)]
		public bool Normalized { get; set; }
	}
}
