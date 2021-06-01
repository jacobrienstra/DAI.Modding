using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionPartnerIsTacticsTarget : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider_Self> Entity { get; set; }

		[FieldOffset(12, 40)]
		public TacticsTarget Target { get; set; }
	}
}
