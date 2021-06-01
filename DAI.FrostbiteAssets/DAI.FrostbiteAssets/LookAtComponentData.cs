using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LookAtComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public List<LookAtLayerInfo> Layers { get; set; }

		[FieldOffset(100, 184)]
		public ExternalObject<LookAtLayers> LayersAsset { get; set; }

		[FieldOffset(104, 192)]
		public int LookAtPointId { get; set; }

		[FieldOffset(108, 200)]
		public AntRef LookAtPosition { get; set; }

		public LookAtComponentData()
		{
			Layers = new List<LookAtLayerInfo>();
		}
	}
}
