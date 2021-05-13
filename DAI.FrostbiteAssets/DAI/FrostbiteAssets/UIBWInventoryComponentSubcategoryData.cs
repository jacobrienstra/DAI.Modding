namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBWInventoryComponentSubcategoryData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int Subcategory { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference SubcategoryLabel { get; set; }

		[FieldOffset(8, 32)]
		public string IconFrameLabel { get; set; }

		[FieldOffset(12, 40)]
		public bool SubHideInMultiplayer { get; set; }
	}
}
