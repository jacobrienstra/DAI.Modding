namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PartyMemberUIData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int PartyMemberID { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference PartyMemberName { get; set; }

		[FieldOffset(8, 32)]
		public LocalizedStringReference LevelClass { get; set; }

		[FieldOffset(12, 56)]
		public LocalizedStringReference CardName { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<TextureAsset> SlotPortrait { get; set; }

		[FieldOffset(20, 88)]
		public string DefaultCardPortraitPath { get; set; }

		[FieldOffset(24, 96)]
		public UIDataSourceInfo CardPortraitData { get; set; }

		[FieldOffset(40, 128)]
		public PlotFlagReference Approval { get; set; }

		[FieldOffset(56, 168)]
		public bool VisibleInPartyList { get; set; }
	}
}
