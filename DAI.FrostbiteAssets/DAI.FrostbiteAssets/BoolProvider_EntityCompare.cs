using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_EntityCompare : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> FirstEntityProvider { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<EntityProvider> SecondEntityProvider { get; set; }

		[FieldOffset(16, 48)]
		public EntityCompareEnum ComparisonType { get; set; }
	}
}
