using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NetworkRegistryAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<DataContainer>> Objects { get; set; }

		public NetworkRegistryAsset()
		{
			Objects = new List<ExternalObject<DataContainer>>();
		}
	}
}
