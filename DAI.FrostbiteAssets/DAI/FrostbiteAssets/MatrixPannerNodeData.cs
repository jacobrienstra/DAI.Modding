using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatrixPannerNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort FrontLeft { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Center { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort FrontRight { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort RearLeft { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort Lfe { get; set; }

		[FieldOffset(56, 240)]
		public AudioGraphNodePort RearRight { get; set; }

		[FieldOffset(64, 272)]
		public AudioGraphNodePort FarRearLeft { get; set; }

		[FieldOffset(72, 304)]
		public AudioGraphNodePort FarRearRight { get; set; }

		[FieldOffset(80, 336)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(88, 368)]
		public MatrixOutputChannelCount OutputChannelCount { get; set; }
	}
}
