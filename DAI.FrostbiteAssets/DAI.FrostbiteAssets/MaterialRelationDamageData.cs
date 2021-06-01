namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialRelationDamageData : PhysicsPropertyRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public float CollisionDamageMultiplier { get; set; }

		[FieldOffset(12, 44)]
		public float CollisionDamageThreshold { get; set; }

		[FieldOffset(16, 48)]
		public float DamageProtectionMultiplier { get; set; }

		[FieldOffset(20, 52)]
		public float DamagePenetrationMultiplier { get; set; }

		[FieldOffset(24, 56)]
		public float DamageProtectionThreshold { get; set; }

		[FieldOffset(28, 60)]
		public float ExplosionCoverDamageModifier { get; set; }

		[FieldOffset(32, 64)]
		public bool InflictsDemolitionDamage { get; set; }

		[FieldOffset(33, 65)]
		public bool AllowClientDestruction { get; set; }
	}
}
