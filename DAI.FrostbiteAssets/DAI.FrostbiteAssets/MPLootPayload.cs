namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPLootPayload : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public int Value { get; set; }
	}
}
