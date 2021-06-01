namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIItemDisplayCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public ExternalObject<BWIntegralStat> LevelStat { get; set; }

		[FieldOffset(36, 144)]
		public LocalizedStringReference LevelLabel { get; set; }
	}
}
