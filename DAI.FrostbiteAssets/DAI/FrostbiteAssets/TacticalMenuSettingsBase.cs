namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticalMenuSettingsBase : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public ExternalObject<BWTacticalMenuPotionItem> TopItem { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<BWTacticalMenuPotionItem> TopRightItem { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<BWTacticalMenuPartyCommandItem> RightItem { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<BWTacticalMenuPartyCommandItem> BottomRightItem { get; set; }

		[FieldOffset(28, 104)]
		public ExternalObject<BWTacticalMenuAbilityItem> BottomItem { get; set; }

		[FieldOffset(32, 112)]
		public ExternalObject<BWTacticalMenuPartyCommandItem> BottomLeftItem { get; set; }

		[FieldOffset(36, 120)]
		public ExternalObject<BWTacticalMenuPartyCommandItem> LeftItem { get; set; }

		[FieldOffset(40, 128)]
		public ExternalObject<BWTacticalMenuPotionItem> TopLeftItem { get; set; }
	}
}
