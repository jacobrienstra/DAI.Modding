namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class VariationLink
	{
		[FieldOffset(0, 0)]
		public ulong VariationKey { get; set; }

		[FieldOffset(8, 8)]
		public uint ObjectVariationHash { get; set; }
	}
}
