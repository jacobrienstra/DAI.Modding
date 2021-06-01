using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWActivatedAbility : BWAbility
	{
		[FieldOffset(92, 288)]
		public List<BWDepletableStatValuePair> Cost { get; set; }

		[FieldOffset(96, 296)]
		public float MinHoldTime { get; set; }

		[FieldOffset(100, 304)]
		public ExternalObject<BWRange> MaximumRange { get; set; }

		[FieldOffset(104, 312)]
		public List<BWTimelineTagRef> RequiredTimelineTags { get; set; }

		[FieldOffset(108, 320)]
		public List<BWTimelineTagRef> ProhibitedTimelineTags { get; set; }

		[FieldOffset(112, 328)]
		public BWAbilityTargetType TargetType { get; set; }

		[FieldOffset(116, 336)]
		public ExternalObject<BoolProvider> ActivationConditional { get; set; }

		[FieldOffset(120, 344)]
		public List<ExternalObject<DataContainer>> AbilityVariations { get; set; }

		[FieldOffset(124, 352)]
		public DelayLoadBundleReference CSMStateRuntimeRef { get; set; }

		[FieldOffset(132, 368)]
		public uint SpeechCommandHash { get; set; }

		[FieldOffset(136, 372)]
		public BWAbilityAutoTargetType AutoTargetType { get; set; }

		[FieldOffset(140, 376)]
		public bool IgnoreRangeRestrictionForPlayer { get; set; }

		[FieldOffset(141, 377)]
		public bool RequiresLineOfSightToTarget { get; set; }

		[FieldOffset(142, 378)]
		public bool TargetIsOptional { get; set; }

		[FieldOffset(143, 379)]
		public bool TargetCanBeDead { get; set; }

		[FieldOffset(144, 380)]
		public bool IsMappable { get; set; }

		[FieldOffset(145, 381)]
		public bool DisableMappingByPlayer { get; set; }

		[FieldOffset(146, 382)]
		public bool IsCombatAbility { get; set; }

		[FieldOffset(147, 383)]
		public bool IsOffensiveAbility { get; set; }

		[FieldOffset(148, 384)]
		public bool IsPotionAbility { get; set; }

		[FieldOffset(149, 385)]
		public bool DeactivateAutoRun { get; set; }

		public BWActivatedAbility()
		{
			Cost = new List<BWDepletableStatValuePair>();
			RequiredTimelineTags = new List<BWTimelineTagRef>();
			ProhibitedTimelineTags = new List<BWTimelineTagRef>();
			AbilityVariations = new List<ExternalObject<DataContainer>>();
		}
	}
}
