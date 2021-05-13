using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NumberGeneratorNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Trigger { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Min { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Max { get; set; }

		[FieldOffset(32, 144)]
		public NumberGeneratorMode Mode { get; set; }

		[FieldOffset(36, 148)]
		public AudioGraphNodePort Y { get; set; }

		[FieldOffset(44, 180)]
		public NumberGeneratorNodeVersion Version { get; set; }
	}
}
