namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CraftingMaterialStats : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWModifiableStat> Stat { get; set; }

		[FieldOffset(4, 8)]
		public DelegateNoArgs_float Script { get; set; }

		[FieldOffset(8, 16)]
		public float Modifier { get; set; }
	}
}
