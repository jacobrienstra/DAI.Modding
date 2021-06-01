namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformProvider_Mix : TransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> Rotation { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<TransformProvider> Translation { get; set; }
	}
}
