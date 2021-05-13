namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SyncedGameSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public uint DifficultyIndex { get; set; }

		[FieldOffset(20, 44)]
		public float ManDownTimeModifier { get; set; }

		[FieldOffset(24, 48)]
		public float BulletDamageModifier { get; set; }

		[FieldOffset(28, 52)]
		public float MaxAllowedLatency { get; set; }

		[FieldOffset(32, 56)]
		public bool DisableToggleEntryCamera { get; set; }

		[FieldOffset(33, 57)]
		public bool DisableRegenerateHealth { get; set; }

		[FieldOffset(34, 58)]
		public bool EnableFriendlyFire { get; set; }

		[FieldOffset(35, 59)]
		public bool AllowClientSideDamageArbitration { get; set; }

		[FieldOffset(36, 60)]
		public bool ForceReloadWholeMags { get; set; }
	}
}
