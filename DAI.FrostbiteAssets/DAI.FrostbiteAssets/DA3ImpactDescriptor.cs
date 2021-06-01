using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3ImpactDescriptor : DataContainer
	{
		[FieldOffset(8, 24)]
		public Delegate_float OverrideComputedDamage { get; set; }

		[FieldOffset(20, 48)]
		public List<DamageCalculationModifier> DamageCalculationModifiers { get; set; }

		[FieldOffset(24, 56)]
		public BWCSMReactionTypeRef ReactionType { get; set; }

		[FieldOffset(32, 72)]
		public BWTimelineReference ImpactPackage { get; set; }

		[FieldOffset(36, 80)]
		public float TranslationDistance { get; set; }

		[FieldOffset(40, 88)]
		public ExternalObject<DA3DamageTypeSource> DamageTypeSource { get; set; }

		[FieldOffset(44, 96)]
		public int CollisionHash { get; set; }

		[FieldOffset(48, 100)]
		public bool ApplyDamage { get; set; }

		[FieldOffset(49, 101)]
		public bool NonLethal { get; set; }

		[FieldOffset(50, 102)]
		public bool TriggerDamageDealtMessage { get; set; }

		[FieldOffset(51, 103)]
		public bool TriggerHealthDamageDealtMessage { get; set; }

		[FieldOffset(52, 104)]
		public bool TriggerDamageReceivedMessage { get; set; }

		[FieldOffset(53, 105)]
		public bool PlayImpactEffects { get; set; }

		public DA3ImpactDescriptor()
		{
			DamageCalculationModifiers = new List<DamageCalculationModifier>();
		}
	}
}
