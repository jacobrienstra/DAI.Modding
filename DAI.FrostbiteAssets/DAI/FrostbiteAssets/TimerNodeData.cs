using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TimerNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Start { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Stop { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Period { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Tick { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort Progress { get; set; }

		[FieldOffset(48, 208)]
		public TimerMode Mode { get; set; }
	}
}
