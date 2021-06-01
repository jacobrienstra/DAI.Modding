using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetTacticsTargetSlot : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<EntityProvider_Self> Entity { get; set; }

		[FieldOffset(32, 80)]
		public TargetSlot Slot { get; set; }

		[FieldOffset(36, 88)]
		public ExternalObject<TargetListProvider> List { get; set; }
	}
}
