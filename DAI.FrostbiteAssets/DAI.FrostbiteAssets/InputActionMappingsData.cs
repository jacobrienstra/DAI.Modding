using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InputActionMappingsData : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<ExternalObject<DataContainer>> Mappings { get; set; }

		public InputActionMappingsData()
		{
			Mappings = new List<ExternalObject<DataContainer>>();
		}
	}
}
