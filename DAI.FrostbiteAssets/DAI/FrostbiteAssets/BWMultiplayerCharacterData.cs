using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMultiplayerCharacterData : Asset
	{
		[FieldOffset(12, 72)]
		public int HubArchetypeID { get; set; }

		[FieldOffset(16, 76)]
		public int WeaponStyle { get; set; }

		[FieldOffset(20, 80)]
		public int WeaponStyleAlt { get; set; }

		[FieldOffset(24, 88)]
		public LocalizedStringReference DefaultCharacterName { get; set; }

		[FieldOffset(28, 112)]
		public LocalizedStringReference DisplayableArchetypeName { get; set; }

		[FieldOffset(32, 136)]
		public LocalizedStringReference DisplayableArchetypeLockedName { get; set; }

		[FieldOffset(36, 160)]
		public LocalizedStringReference DisplayableShortDescription { get; set; }

		[FieldOffset(40, 184)]
		public LocalizedStringReference DisplayableDescription { get; set; }

		[FieldOffset(44, 208)]
		public LocalizedStringReference DisplayableLockedDescription { get; set; }

		[FieldOffset(48, 232)]
		public UITextureAtlasTextureReference ClassIcon { get; set; }

		[FieldOffset(68, 272)]
		public List<ExternalObject<BWMultiplayerCharacterEquipment>> DefaultEquipment { get; set; }

		public BWMultiplayerCharacterData()
		{
			DefaultEquipment = new List<ExternalObject<BWMultiplayerCharacterEquipment>>();
		}
	}
}
