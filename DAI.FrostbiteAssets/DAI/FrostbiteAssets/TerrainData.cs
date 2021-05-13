using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class TerrainData : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<SingleTerrainLayerData>> TerrainLayers { get; set; }

		[FieldOffset(16, 80)]
		public long TerrainStreamingTreeResource { get; set; }

		[FieldOffset(24, 88)]
		public long VisualResource { get; set; }

		[FieldOffset(32, 96)]
		public long TerrainLayerCombinationsResource { get; set; }

		[FieldOffset(40, 104)]
		public bool DestructionMaskEnable { get; set; }

		public TerrainData()
		{
			TerrainLayers = new List<ExternalObject<SingleTerrainLayerData>>();
		}
	}
}
