namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StackedItemReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint NameHash { get; set; }

		[FieldOffset(4, 8)]
		public string Name { get; set; }
	}
}
