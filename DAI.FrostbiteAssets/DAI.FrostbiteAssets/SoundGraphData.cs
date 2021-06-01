using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundGraphData : AudioGraphData
	{
		[FieldOffset(28, 80)]
		public SoundGraphInfo Info { get; set; }

		[FieldOffset(52, 120)]
		public List<ExternalObject<AudioGraphNodeData>> InputParameters { get; set; }

		[FieldOffset(56, 128)]
		public List<ExternalObject<AudioGraphNodeData>> OutputParameters { get; set; }

		[FieldOffset(60, 136)]
		public List<ExternalObject<OutputNodeData>> InputEvents { get; set; }

		[FieldOffset(64, 144)]
		public List<ExternalObject<DirectOutputNodeData>> OutputEvents { get; set; }

		public SoundGraphData()
		{
			InputParameters = new List<ExternalObject<AudioGraphNodeData>>();
			OutputParameters = new List<ExternalObject<AudioGraphNodeData>>();
			InputEvents = new List<ExternalObject<OutputNodeData>>();
			OutputEvents = new List<ExternalObject<DirectOutputNodeData>>();
		}
	}
}
