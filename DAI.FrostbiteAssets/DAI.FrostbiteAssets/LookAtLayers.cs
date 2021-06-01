using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LookAtLayers : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<LookAtLayerInfo> Layers { get; set; }

		public LookAtLayers()
		{
			Layers = new List<LookAtLayerInfo>();
		}
	}
}
