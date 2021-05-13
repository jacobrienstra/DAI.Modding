namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformProvider_Facing : TransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> Location { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<TransformProvider> Facing { get; set; }

		[FieldOffset(16, 48)]
		public bool FlattenY { get; set; }
	}
}
