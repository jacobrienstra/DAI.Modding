namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICharNameCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public LocalizedStringReference LevelLabel { get; set; }

		[FieldOffset(36, 160)]
		public ExternalObject<BWIntegralStat> LevelStat { get; set; }

		[FieldOffset(40, 168)]
		public ExternalObject<UIPartyMemberDataAsset> PartyMemberData { get; set; }
	}
}
