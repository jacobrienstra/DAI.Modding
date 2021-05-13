using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionAbilityInputAction : BWConditional
	{
		[FieldOffset(8, 32)]
		public DataProvider_InputActionConditions Condition { get; set; }

		[FieldOffset(12, 36)]
		public float Time { get; set; }
	}
}
