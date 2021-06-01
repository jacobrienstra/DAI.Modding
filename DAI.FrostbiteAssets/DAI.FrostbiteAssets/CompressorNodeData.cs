using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CompressorNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Sidechain { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Threshold { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Ratio { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort AttackTime { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort ReleaseTime { get; set; }

		[FieldOffset(56, 240)]
		public AudioGraphNodePort UseSidechain { get; set; }

		[FieldOffset(64, 272)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(72, 304)]
		public CompressorChannelMode ChannelMode { get; set; }

		[FieldOffset(76, 308)]
		public SoundGraphPluginRef Plugin { get; set; }
	}
}
