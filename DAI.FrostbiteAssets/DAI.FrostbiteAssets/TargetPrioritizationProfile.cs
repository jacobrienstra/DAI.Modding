using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TargetPrioritizationProfile : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public float UpdatePeriod { get; set; }

		[FieldOffset(16, 76)]
		public float ExistingThreatBias { get; set; }

		[FieldOffset(20, 80)]
		public float ProximitySquelch { get; set; }

		[FieldOffset(24, 84)]
		public float ThreatDecayRate { get; set; }

		[FieldOffset(28, 88)]
		public float ThreatDecayConstant { get; set; }

		[FieldOffset(32, 92)]
		public float GlobalThreatWeight { get; set; }

		[FieldOffset(36, 96)]
		public float OuterDistanceThreatRange { get; set; }

		[FieldOffset(40, 100)]
		public float OuterDistanceThreatMultiplier { get; set; }

		[FieldOffset(44, 104)]
		public float TicketTakingThreatBonus { get; set; }

		[FieldOffset(48, 112)]
		public List<BWTicketTypes> TicketTypesForBonus { get; set; }

		[FieldOffset(52, 120)]
		public float APTMaxScore { get; set; }

		[FieldOffset(56, 124)]
		public float APTActiveDecay { get; set; }

		[FieldOffset(60, 128)]
		public float APTPassiveDecay { get; set; }

		[FieldOffset(64, 132)]
		public bool ProximityFallbackEnabled { get; set; }

		public TargetPrioritizationProfile()
		{
			TicketTypesForBonus = new List<BWTicketTypes>();
		}
	}
}
