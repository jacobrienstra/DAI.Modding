using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RangeMapperNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(24, 112)]
		public List<RangeMapperEntry> Ranges { get; set; }

		[FieldOffset(28, 120)]
		public float DefaultOutputValue { get; set; }

		[FieldOffset(32, 124)]
		public bool DefaultOutputValueEnabled { get; set; }

		public RangeMapperNodeData()
		{
			Ranges = new List<RangeMapperEntry>();
		}
	}
}
