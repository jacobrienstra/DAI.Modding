using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AppearanceComponentSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public AppearanceCustomizations AppearanceCustomizations { get; set; }

		[FieldOffset(20, 48)]
		public List<ExternalObject<DataContainer>> MeshSets { get; set; }

		[FieldOffset(24, 56)]
		public List<ExternalObject<Asset>> Gen3ClothSets { get; set; }

		public AppearanceComponentSpawnData()
		{
			MeshSets = new List<ExternalObject<DataContainer>>();
			Gen3ClothSets = new List<ExternalObject<Asset>>();
		}
	}
}
