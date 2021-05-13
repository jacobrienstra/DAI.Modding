using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_GeneratedThreatModifier : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public Delegate_float ModifierValue { get; set; }

		[FieldOffset(40, 96)]
		public ExternalObject<EntityProvider_Self> ThreatGiver { get; set; }

		[FieldOffset(44, 104)]
		public ExternalObject<EntityProvider_Partner> ThreatTaker { get; set; }

		[FieldOffset(48, 112)]
		public List<BWAbilityTagRef> AbilityTags { get; set; }

		public BWCSMAction_GeneratedThreatModifier()
		{
			AbilityTags = new List<BWAbilityTagRef>();
		}
	}
}
