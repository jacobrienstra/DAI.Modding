using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DifficultyData : DataContainer
	{
		[FieldOffset(8, 24)]
		public Difficulty Difficulty { get; set; }

		[FieldOffset(12, 28)]
		public PersistenceGameType GameType { get; set; }

		[FieldOffset(16, 32)]
		public Vec3 StickyBoxModifier { get; set; }

		[FieldOffset(32, 48)]
		public Vec3 SnapBoxModifier { get; set; }

		[FieldOffset(48, 64)]
		public string ReadableName { get; set; }

		[FieldOffset(52, 72)]
		public float HumanHealthModifier { get; set; }

		[FieldOffset(56, 76)]
		public float FriendsHealthModifier { get; set; }

		[FieldOffset(60, 80)]
		public float EnemiesHealthModifier { get; set; }

		[FieldOffset(64, 84)]
		public float FriendlyDamageModifier { get; set; }

		[FieldOffset(68, 88)]
		public float VehicleDamageModifier { get; set; }

		[FieldOffset(72, 92)]
		public float HumanInCriticalHealth { get; set; }

		[FieldOffset(76, 96)]
		public float HumanInCriticalHealthDamageModifier { get; set; }

		[FieldOffset(80, 100)]
		public float HumanRegenerationRateModifier { get; set; }

		[FieldOffset(84, 104)]
		public float CriticalFakeImmortalModifier { get; set; }

		[FieldOffset(88, 108)]
		public float InteractiveManDownDamageModifier { get; set; }

		[FieldOffset(92, 112)]
		public float InteractiveManDownTimeMultiplier { get; set; }

		[FieldOffset(96, 116)]
		public float InteractiveManDownReviveTime { get; set; }

		[FieldOffset(100, 120)]
		public int AdrenalineKillLimit { get; set; }

		[FieldOffset(104, 124)]
		public Vec2 AttractDistanceFallOffModifier { get; set; }

		[FieldOffset(112, 132)]
		public float AttractSoftZoneModifier { get; set; }

		[FieldOffset(116, 136)]
		public float AttractUserInputMultiplierModifier { get; set; }

		[FieldOffset(120, 140)]
		public float SnapZoomPostTimeNoInputModifier { get; set; }

		[FieldOffset(124, 144)]
		public float SnapZoomPostTimeModifier { get; set; }

		[FieldOffset(128, 148)]
		public float SuckZoomModifier { get; set; }

		[FieldOffset(132, 152)]
		public float AiBulletDamageHumanCooldown { get; set; }

		[FieldOffset(136, 160)]
		public ExternalObject<Dummy> AIData { get; set; }

		[FieldOffset(140, 168)]
		public bool UsePitchZoomSnap { get; set; }
	}
}
