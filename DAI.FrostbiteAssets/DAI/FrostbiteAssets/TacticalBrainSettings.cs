using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticalBrainSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public ExternalObject<TacticsCommandUseAbilityData> PlayerIssuedUseCommandData { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<TacticsCommandMoveToPositionData> PlayerIssuedMovementCommandData { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<TacticsCommandFollowLeaderData> PlayerIssuedFollowLeaderCommandData { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<TacticsCommandInteractData> PlayerIssuedInteractCommandData { get; set; }

		[FieldOffset(28, 104)]
		public ExternalObject<ObjectiveWaypointData> ObjectiveWaypoint { get; set; }

		[FieldOffset(32, 112)]
		public ExternalObject<BWActivatedAbility> AbilityForInteractions { get; set; }

		[FieldOffset(36, 120)]
		public BWAbilityAlias AttackAbility { get; set; }

		[FieldOffset(40, 128)]
		public ExternalObject<FloatProvider_FromAsset> LOSTestHeight { get; set; }

		[FieldOffset(44, 136)]
		public int HoldPositionObjective { get; set; }

		[FieldOffset(48, 140)]
		public int GuardAllyObjective { get; set; }

		[FieldOffset(52, 144)]
		public int DisengageObjective { get; set; }

		[FieldOffset(56, 148)]
		public int AttackEnemyObjective { get; set; }

		[FieldOffset(60, 152)]
		public int MoveToPartyObjective { get; set; }

		[FieldOffset(64, 160)]
		public List<AbilityUsageDefault> AbilityUsageDefaults { get; set; }

		[FieldOffset(68, 168)]
		public List<AISharedCooldown> AISharedCooldowns { get; set; }

		public TacticalBrainSettings()
		{
			AbilityUsageDefaults = new List<AbilityUsageDefault>();
			AISharedCooldowns = new List<AISharedCooldown>();
		}
	}
}
