namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_FloatInput2D : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider_Self> Entity { get; set; }

		[FieldOffset(12, 40)]
		public int ActionXAxis { get; set; }

		[FieldOffset(16, 44)]
		public int ActionYAxis { get; set; }
	}
}
