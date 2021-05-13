using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioGraphData : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<ExternalObject<DataContainer>> Nodes { get; set; }

		[FieldOffset(12, 32)]
		public List<ExternalObject<AudioGraphNodeData>> PublicParameters { get; set; }

		[FieldOffset(16, 40)]
		public List<ExternalObject<OutputNodeData>> PublicEvents { get; set; }

		[FieldOffset(20, 48)]
		public List<ExternalObject<OutputNodeData>> PublicAssetParameters { get; set; }

		[FieldOffset(24, 56)]
		public short PublicValueCount { get; set; }

		[FieldOffset(26, 58)]
		public short ValueCount { get; set; }

		public AudioGraphData()
		{
			Nodes = new List<ExternalObject<DataContainer>>();
			PublicParameters = new List<ExternalObject<AudioGraphNodeData>>();
			PublicEvents = new List<ExternalObject<OutputNodeData>>();
			PublicAssetParameters = new List<ExternalObject<OutputNodeData>>();
		}
	}
}
