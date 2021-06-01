using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CharacterEntityData : ControllableEntityData
	{
		[FieldOffset(160, 272)]
		public float MaxHealth { get; set; }

		[FieldOffset(164, 276)]
		public PersonViewMode DefaultViewMode { get; set; }

		[FieldOffset(168, 280)]
		public PlayerSpawnType PlayerSpawnType { get; set; }

		[FieldOffset(172, 288)]
		public ExternalObject<Dummy> VoiceOverInfo { get; set; }

		[FieldOffset(176, 296)]
		public ExternalObject<Dummy> Sound { get; set; }

		[FieldOffset(180, 304)]
		public bool CharacterLightingEnable { get; set; }
	}
}
