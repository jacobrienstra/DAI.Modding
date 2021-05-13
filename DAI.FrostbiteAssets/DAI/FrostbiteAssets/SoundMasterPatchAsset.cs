using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundMasterPatchAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<SoundGraphData> Graph { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<BusNodeData>> Busses { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<BusNodeData> RwMovieBus { get; set; }

		public SoundMasterPatchAsset()
		{
			Busses = new List<ExternalObject<BusNodeData>>();
		}
	}
}
