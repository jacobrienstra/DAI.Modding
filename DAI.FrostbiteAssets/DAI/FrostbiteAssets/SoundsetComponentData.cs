using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SoundsetComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public List<ExternalObject<DataContainer>> FilterData { get; set; }

		public SoundsetComponentData()
		{
			FilterData = new List<ExternalObject<DataContainer>>();
		}
	}
}
