using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMReactionPairing : LinkObject
	{
		[FieldOffset(0, 0)]
		public BWCSMReactionTypeRef ReactionType { get; set; }

		[FieldOffset(8, 16)]
		public int DamageType { get; set; }

		[FieldOffset(12, 20)]
		public float MinMagnitude { get; set; }

		[FieldOffset(16, 24)]
		public float MaxMagnitude { get; set; }

		[FieldOffset(20, 28)]
		public float AngleOffset { get; set; }

		[FieldOffset(24, 32)]
		public float AngleSpan { get; set; }

		[FieldOffset(28, 40)]
		public List<ReactionHitBody> HitBodies { get; set; }

		[FieldOffset(32, 48)]
		public ExternalObject<CSMStateReference> StateRef { get; set; }

		[FieldOffset(36, 56)]
		public BWTimelineReference TimelineRef { get; set; }

		[FieldOffset(40, 64)]
		public List<BWTimelineTagRef> AddTags { get; set; }

		[FieldOffset(44, 72)]
		public List<DamageCalculationModifier> DamageCalculationModifiers { get; set; }

		[FieldOffset(48, 80)]
		public bool TriggerDamageDealtMessage { get; set; }

		public BWCSMReactionPairing()
		{
			HitBodies = new List<ReactionHitBody>();
			AddTags = new List<BWTimelineTagRef>();
			DamageCalculationModifiers = new List<DamageCalculationModifier>();
		}
	}
}
