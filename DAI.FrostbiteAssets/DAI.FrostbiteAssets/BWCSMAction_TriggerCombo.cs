using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_TriggerCombo : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ComboType InstigatorType { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<EntityProvider_Self> Target { get; set; }

		[FieldOffset(36, 88)]
		public int StoredPlayerA { get; set; }

		[FieldOffset(40, 96)]
		public ExternalObject<EntityProvider_Caster> InstigatorB { get; set; }
	}
}
