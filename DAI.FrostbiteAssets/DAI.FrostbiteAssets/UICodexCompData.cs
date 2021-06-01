namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICodexCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public string LockedPageTexturePath { get; set; }

		[FieldOffset(36, 144)]
		public string LockedCardTexturePath { get; set; }

		[FieldOffset(40, 152)]
		public string LockedMapTexturePath { get; set; }

		[FieldOffset(44, 160)]
		public string DefaultPageTexturePath { get; set; }

		[FieldOffset(48, 168)]
		public string DefaultCardTexturePath { get; set; }

		[FieldOffset(52, 176)]
		public string DefaultCategoryTexturePath { get; set; }
	}
}
