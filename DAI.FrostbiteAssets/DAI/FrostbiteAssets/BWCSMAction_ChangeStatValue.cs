using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ChangeStatValue : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<EntityListProvider> EntityList { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<BWStat> ChangingStat { get; set; }

		[FieldOffset(36, 88)]
		public BWCSMAction_ChangeStatValueOperation Operation { get; set; }

		[FieldOffset(40, 96)]
		public Delegate_float FloatAmount { get; set; }
	}
}
