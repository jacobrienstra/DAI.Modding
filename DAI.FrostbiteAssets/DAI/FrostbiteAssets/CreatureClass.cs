using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureClass : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference ClassName { get; set; }

		[FieldOffset(16, 96)]
		public LocalizedStringReference ClassNameFemale { get; set; }

		[FieldOffset(20, 120)]
		public PartyMemberClassType ClassType { get; set; }

		[FieldOffset(24, 128)]
		public UITextureAtlasTextureReference ClassIcon { get; set; }
	}
}
