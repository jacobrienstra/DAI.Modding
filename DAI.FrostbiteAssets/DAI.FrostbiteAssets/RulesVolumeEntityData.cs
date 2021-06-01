using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class RulesVolumeEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public RulesVolumeType VolumeType { get; set; }

		[FieldOffset(84, 184)]
		public ExternalObject<Dummy> VisualEffect { get; set; }

		[FieldOffset(88, 192)]
		public MaterialDecl MaterialPair { get; set; }

		[FieldOffset(92, 208)]
		public ExternalObject<TransformProvider> VolumeTransform { get; set; }

		[FieldOffset(96, 216)]
		public float Parameter { get; set; }

		[FieldOffset(100, 224)]
		public BWAbilityDesignerProperty PropertyTest { get; set; }

		[FieldOffset(108, 240)]
		public RulesVolumePropertyTestOperation PropertyTestComparison { get; set; }

		[FieldOffset(112, 244)]
		public float MaxIncomingAngle { get; set; }

		[FieldOffset(116, 248)]
		public BWTimelineReference TimelineAppliedToMeleeAttackerOnMeleeAttack { get; set; }

		[FieldOffset(120, 256)]
		public BWTimelineReference TimelineAppliedToAttachedCreatureOnMeleeAttack { get; set; }

		[FieldOffset(124, 264)]
		public BWTimelineReference TimelineAppliedToProjectileCasterOnProjectileCollision { get; set; }

		[FieldOffset(128, 272)]
		public BWTimelineReference TimelineAppliedToAttachedCreatureOnProjectileCollision { get; set; }

		[FieldOffset(132, 280)]
		public ExternalObject<BWCSMReactionOverrideSet> OverrideReactionSet { get; set; }

		[FieldOffset(136, 288)]
		public int OverrideReactionType { get; set; }

		[FieldOffset(140, 292)]
		public bool EffectOnEnter { get; set; }

		[FieldOffset(141, 293)]
		public bool EffectUndoneOnExit { get; set; }

		[FieldOffset(142, 294)]
		public bool IgnoreProjectilesSpawnedInside { get; set; }

		[FieldOffset(143, 295)]
		public bool StayAttached { get; set; }

		[FieldOffset(144, 296)]
		public bool InteractsWithMeleeCollisions { get; set; }

		[FieldOffset(145, 297)]
		public bool ProtectAttachedCreatureFromMeleeAttacks { get; set; }
	}
}
