using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WaveSwitcherNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Index { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Advance { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Wave { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort IndexChanged { get; set; }

		[FieldOffset(40, 176)]
		public List<ExternalObject<OutputNodeData>> Waves { get; set; }

		[FieldOffset(44, 184)]
		public float DefaultIndex { get; set; }

		[FieldOffset(48, 188)]
		public bool IsRandom { get; set; }

		[FieldOffset(49, 189)]
		public bool RandomStartIndex { get; set; }

		public WaveSwitcherNodeData()
		{
			Waves = new List<ExternalObject<OutputNodeData>>();
		}
	}
}
