using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_ComparisonType : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public BWComparisonType Value { get; set; }
	}
}
