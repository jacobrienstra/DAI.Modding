using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EmitterData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public List<ExternalObject<DataContainer>> EmitterAssets { get; set; }

		public EmitterData()
		{
			EmitterAssets = new List<ExternalObject<DataContainer>>();
		}
	}
}
