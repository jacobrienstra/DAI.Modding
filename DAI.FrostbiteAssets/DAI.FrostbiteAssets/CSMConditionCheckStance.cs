using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionCheckStance : BWConditional
	{
		[FieldOffset(8, 32)]
		public BWStance Stance { get; set; }
	}
}
