namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMultiplayerCharacterInfoBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference LocalizedClassLabelString { get; set; }

		[FieldOffset(12, 48)]
		public LocalizedStringReference LocalizedLevelLabelString { get; set; }

		[FieldOffset(16, 72)]
		public LocalizedStringReference LocalizedNameLabelString { get; set; }

		[FieldOffset(20, 96)]
		public UIDataSourceInfo CurrentCharacter { get; set; }

		[FieldOffset(36, 128)]
		public UIDataSourceInfo CharacterList { get; set; }
	}
}
