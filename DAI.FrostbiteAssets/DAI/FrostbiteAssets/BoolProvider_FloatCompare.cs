using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_FloatCompare : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<FloatProvider> Param1 { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<FloatProvider> Param2 { get; set; }

		[FieldOffset(16, 48)]
		public FloatCompareEnum ComparisonType { get; set; }
	}
}
