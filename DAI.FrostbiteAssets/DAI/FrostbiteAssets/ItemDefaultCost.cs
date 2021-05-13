namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemDefaultCost : LinkObject
	{
		[FieldOffset(0, 0)]
		public DelegateNoArgs_int Script { get; set; }

		[FieldOffset(4, 8)]
		public int LevelOverride { get; set; }

		[FieldOffset(8, 12)]
		public int QualityOverride { get; set; }

		[FieldOffset(12, 16)]
		public bool IsRecipe { get; set; }
	}
}
