using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_AbilityValue : FloatProvider
	{
		[FieldOffset(8, 32)]
		public AbilityValueType ValueType { get; set; }
	}
}
