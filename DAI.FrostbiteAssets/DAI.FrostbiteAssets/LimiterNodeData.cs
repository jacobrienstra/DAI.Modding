using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LimiterNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Sidechain { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Threshold { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort ReleaseTime { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort UseSidechain { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(56, 240)]
		public LimiterChannelMode ChannelMode { get; set; }

		[FieldOffset(60, 244)]
		public SoundGraphPluginRef Plugin { get; set; }
	}
}
