using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConfigurableRangeMapperNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort InputValue { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort OutputValue { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort DefaultOutputValue { get; set; }

		[FieldOffset(32, 144)]
		public List<ExternalObject<AudioGraphNodeData>> Ranges { get; set; }

		[FieldOffset(36, 152)]
		public bool DefaultOutputValueEnabled { get; set; }

		public ConfigurableRangeMapperNodeData()
		{
			Ranges = new List<ExternalObject<AudioGraphNodeData>>();
		}
	}
}
