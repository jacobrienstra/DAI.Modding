using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ClothComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public List<ExternalObject<DataContainer>> Instances { get; set; }

		public ClothComponentData()
		{
			Instances = new List<ExternalObject<DataContainer>>();
		}
	}
}
