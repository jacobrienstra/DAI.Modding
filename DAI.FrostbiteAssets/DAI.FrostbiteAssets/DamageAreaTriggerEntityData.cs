using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DamageAreaTriggerEntityData : TriggerEntityData
	{
		[FieldOffset(96, 192)]
		public float DamagePerSecond { get; set; }

		[FieldOffset(100, 196)]
		public float DamageTime { get; set; }

		[FieldOffset(104, 200)]
		public TeamId TeamOfImmortalCharacters { get; set; }

		[FieldOffset(108, 204)]
		public bool DamageCharacters { get; set; }

		[FieldOffset(109, 205)]
		public bool DamageVehicles { get; set; }

		[FieldOffset(110, 206)]
		public bool DamageBangers { get; set; }

		[FieldOffset(111, 207)]
		public bool ExcludeImmortalCharactersInTeam { get; set; }

		[FieldOffset(112, 208)]
		public bool ExcludeShieldedSoldiers { get; set; }

		[FieldOffset(113, 209)]
		public bool IsNeverTriggeredByPlayer { get; set; }
	}
}
