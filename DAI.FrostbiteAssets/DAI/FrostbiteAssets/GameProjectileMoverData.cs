using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameProjectileMoverData : DataContainer
	{
		[FieldOffset(8, 24)]
		public float GroundClearance { get; set; }

		[FieldOffset(12, 32)]
		public BWTimelineReference TimelineToApplyToCasterOnImpact { get; set; }

		[FieldOffset(16, 40)]
		public BWTimelineReference TimelineToApplyToCasterOnWorldBounce { get; set; }

		[FieldOffset(20, 48)]
		public BWTimelineReference TimelineToApplyToCasterOnWorldImpact { get; set; }

		[FieldOffset(24, 56)]
		public EffectBlueprintData EffectData { get; set; }

		[FieldOffset(32, 72)]
		public float TimeToLiveAfterCollision { get; set; }

		[FieldOffset(36, 76)]
		public GameProjAreaOfEffectVFXOrientation MaterialGridEffectOrientation { get; set; }

		[FieldOffset(40, 80)]
		public float ProximityTriggerDistance { get; set; }

		[FieldOffset(44, 84)]
		public bool GroundAligned { get; set; }

		[FieldOffset(45, 85)]
		public bool StaticCollisionOnly { get; set; }

		[FieldOffset(46, 86)]
		public bool NoTerrainCollisions { get; set; }

		[FieldOffset(47, 87)]
		public bool CollidesWithHomingTargetOnly { get; set; }

		[FieldOffset(48, 88)]
		public bool PassThrough { get; set; }

		[FieldOffset(49, 89)]
		public bool DetonateOnWater { get; set; }

		[FieldOffset(50, 90)]
		public bool DetonateOnProximityToStaticTargetLocation { get; set; }
	}
}
