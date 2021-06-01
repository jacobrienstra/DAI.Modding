using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DataContainerCollectionBlueprint : Blueprint
	{
		[FieldOffset(32, 176)]
		public List<ExternalObject<Asset>> DataContainers { get; set; }

		public DataContainerCollectionBlueprint()
		{
			DataContainers = new List<ExternalObject<Asset>>();
		}
	}
}
