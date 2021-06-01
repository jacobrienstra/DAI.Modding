using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DebrisClusterData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public Vec3 InitRotationRndMul { get; set; }

		[FieldOffset(128, 224)]
		public Vec3 PushVelocityRndMul { get; set; }

		[FieldOffset(144, 240)]
		public Vec3 PushVelocityMul { get; set; }

		[FieldOffset(160, 256)]
		public uint MaxActivePartsCount { get; set; }

		[FieldOffset(164, 260)]
		public float RuntimeClusterLifetime { get; set; }

		[FieldOffset(168, 264)]
		public float RuntimeClusterLifetimeVariance { get; set; }

		[FieldOffset(172, 268)]
		public int RuntimeClusterPartSpawnScale { get; set; }

		[FieldOffset(176, 272)]
		public ExternalObject<CompositeMeshAsset> Mesh { get; set; }

		[FieldOffset(180, 280)]
		public uint CompositePartCount { get; set; }

		[FieldOffset(184, 288)]
		public List<DebrisClusterPartInfoData> PartHierarchy { get; set; }

		[FieldOffset(188, 296)]
		public ExternalObject<PhysicsEntityData> PhysicsData { get; set; }

		[FieldOffset(192, 304)]
		public float ActivationPushForceMul { get; set; }

		[FieldOffset(196, 308)]
		public float ProjectileForceTransferMul { get; set; }

		[FieldOffset(200, 312)]
		public ExternalObject<Dummy> ActivationEffect { get; set; }

		[FieldOffset(204, 320)]
		public float OnPartCollisionSpeedThreshold { get; set; }

		[FieldOffset(208, 328)]
		public ExternalObject<EffectBlueprint> Effect { get; set; }

		[FieldOffset(212, 336)]
		public ExternalObject<Dummy> Explosion { get; set; }

		[FieldOffset(216, 344)]
		public bool PartialDestruction { get; set; }

		[FieldOffset(217, 345)]
		public bool ClientSideOnly { get; set; }

		[FieldOffset(218, 346)]
		public bool ActivateOnSpawn { get; set; }

		[FieldOffset(219, 347)]
		public bool InEffectWorldOnly { get; set; }

		[FieldOffset(220, 348)]
		public bool NoCollision { get; set; }

		[FieldOffset(221, 349)]
		public bool UseOnCollisionEffectOnDespawn { get; set; }

		[FieldOffset(222, 350)]
		public bool OnPartCollisionEnable { get; set; }

		[FieldOffset(223, 351)]
		public bool KillPartsOnCollision { get; set; }

		[FieldOffset(224, 352)]
		public bool DeactivatePartsOnSleep { get; set; }

		[FieldOffset(225, 353)]
		public bool SpawnExplosionOnFirstImpactOnly { get; set; }

		public DebrisClusterData()
		{
			PartHierarchy = new List<DebrisClusterPartInfoData>();
		}
	}
}
