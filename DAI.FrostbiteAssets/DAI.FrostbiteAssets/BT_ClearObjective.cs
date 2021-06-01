using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_ClearObjective : BTTaskFunc
	{
		[FieldOffset(12, 32)]
		public TacticsTarget Target { get; set; }
	}
}
