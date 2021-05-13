using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_CanMoveInStraightLineToTarget : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Destination { get; set; }
	}
}
