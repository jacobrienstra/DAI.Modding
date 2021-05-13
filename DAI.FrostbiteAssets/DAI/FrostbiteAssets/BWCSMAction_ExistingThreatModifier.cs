using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ExistingThreatModifier : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExistingThreatModifierType ModifierType { get; set; }

		[FieldOffset(32, 80)]
		public Delegate_float ModifierValue { get; set; }

		[FieldOffset(44, 104)]
		public ExternalObject<EntityProvider> ThreatGiver { get; set; }

		[FieldOffset(48, 112)]
		public ExternalObject<EntityProvider> ThreatTaker { get; set; }

		[FieldOffset(52, 120)]
		public bool UndoAtEnd { get; set; }
	}
}
