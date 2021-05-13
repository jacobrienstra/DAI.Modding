using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StreamPoolPreset : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<ExternalObject<StreamPoolMapping>> Mappings { get; set; }

		public StreamPoolPreset()
		{
			Mappings = new List<ExternalObject<StreamPoolMapping>>();
		}
	}
}
