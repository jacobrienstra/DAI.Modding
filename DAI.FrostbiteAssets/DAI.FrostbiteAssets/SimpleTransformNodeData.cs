using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SimpleTransformNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort X { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Y { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Z { get; set; }

		[FieldOffset(32, 144)]
		public SimpleTransformOperation Operation { get; set; }

		[FieldOffset(36, 148)]
		public AngleUnit AngleUnit { get; set; }
	}
}
