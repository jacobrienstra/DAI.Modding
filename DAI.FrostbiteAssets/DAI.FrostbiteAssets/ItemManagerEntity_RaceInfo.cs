namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemManagerEntity_RaceInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public int Id { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference Name { get; set; }
	}
}
