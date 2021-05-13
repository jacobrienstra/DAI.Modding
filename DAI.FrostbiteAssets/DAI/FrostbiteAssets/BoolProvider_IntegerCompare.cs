using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_IntegerCompare : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<IntegerProvider> Param1 { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<IntegerProvider> Param2 { get; set; }

		[FieldOffset(16, 48)]
		public IntegerCompareEnum ComparisonType { get; set; }
	}
}
