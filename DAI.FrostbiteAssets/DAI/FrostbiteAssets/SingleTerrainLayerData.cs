using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SingleTerrainLayerData : TerrainLayerData
	{
		[FieldOffset(8, 192)]
		public List<ExternalObject<SingleTerrainLayerData>> MeshScatteringTypes { get; set; }

		public SingleTerrainLayerData()
		{
			MeshScatteringTypes = new List<ExternalObject<SingleTerrainLayerData>>();
		}
	}
}
