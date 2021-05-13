using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterBehaviorSetting : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference SettingName { get; set; }

		[FieldOffset(16, 96)]
		public List<CharacterBehaviorChoice> Choices { get; set; }

		[FieldOffset(20, 104)]
		public uint DefaultChoice { get; set; }

		[FieldOffset(24, 112)]
		public UITextureAtlasTextureReference BehaviorIcon { get; set; }

		[FieldOffset(44, 152)]
		public LocalizedStringReference Description { get; set; }

		public CharacterBehaviorSetting()
		{
			Choices = new List<CharacterBehaviorChoice>();
		}
	}
}
