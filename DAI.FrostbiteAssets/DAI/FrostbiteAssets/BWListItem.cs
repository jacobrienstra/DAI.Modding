namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWListItem : LinkObject
	{
		[FieldOffset(0, 0)]
		public string DisplayLabel { get; set; }

		[FieldOffset(4, 8)]
		public string UniqueID { get; set; }

		[FieldOffset(8, 16)]
		public bool Enabled { get; set; }

		[FieldOffset(9, 17)]
		public bool DisabledInDemoMode { get; set; }
	}
}
