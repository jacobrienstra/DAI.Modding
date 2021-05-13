using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ModifyHealthEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public HealthValueType ValueType { get; set; }

		[FieldOffset(24, 108)]
		public float HealthChangeAmount { get; set; }
	}
}
