namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionArcRange : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> Source { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<TransformProvider> Target { get; set; }

		[FieldOffset(16, 48)]
		public ExternalObject<FloatProvider> MaxDistance { get; set; }

		[FieldOffset(20, 56)]
		public ExternalObject<FloatProvider> MinDistance { get; set; }

		[FieldOffset(24, 64)]
		public ExternalObject<FloatProvider> ArcSize { get; set; }

		[FieldOffset(28, 72)]
		public ExternalObject<FloatProvider> ArcOffset { get; set; }

		[FieldOffset(32, 80)]
		public bool Test2D { get; set; }
	}
}
