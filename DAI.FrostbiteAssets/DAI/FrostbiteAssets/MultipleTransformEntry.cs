using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MultipleTransformEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort Y { get; set; }

		[FieldOffset(16, 56)]
		public AudioGraphNodePort Z { get; set; }

		[FieldOffset(24, 88)]
		public SimpleTransformOperation Operation { get; set; }

		[FieldOffset(28, 92)]
		public AngleUnit AngleUnit { get; set; }
	}
}
