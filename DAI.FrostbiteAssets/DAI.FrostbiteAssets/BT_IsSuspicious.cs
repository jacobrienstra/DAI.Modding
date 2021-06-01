using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_IsSuspicious : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Target { get; set; }
	}
}
