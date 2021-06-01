namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemManagerEntity_PotionData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<PotionItemAsset> Potion { get; set; }

		[FieldOffset(4, 8)]
		public PlotFlagReference UnlockFlag { get; set; }

		[FieldOffset(20, 48)]
		public bool AlwaysUnlocked { get; set; }

		[FieldOffset(21, 49)]
		public byte InitialValueIfShared { get; set; }
	}
}
