using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingCriteria : LinkObject
	{
		[FieldOffset(0, 0)]
		public MatchmakingSizeRule SizeRule { get; set; }

		[FieldOffset(8, 16)]
		public MatchmakingPingSiteRule PingSiteRule { get; set; }

		[FieldOffset(12, 24)]
		public MatchmakingGeolocationRule GeolocationRule { get; set; }

		[FieldOffset(16, 32)]
		public MatchmakingRankedRule RankedRule { get; set; }

		[FieldOffset(20, 40)]
		public List<MatchmakingGenericRule> GenericRules { get; set; }

		[FieldOffset(24, 48)]
		public MatchmakingVirtualizedRule VirtualizedRule { get; set; }

		[FieldOffset(32, 64)]
		public List<MatchmakingUserExtendedDataRule> UEDRules { get; set; }

		[FieldOffset(36, 72)]
		public MatchmakingReputationRequirement ReputationRequirement { get; set; }

		public MatchmakingCriteria()
		{
			GenericRules = new List<MatchmakingGenericRule>();
			UEDRules = new List<MatchmakingUserExtendedDataRule>();
		}
	}
}
