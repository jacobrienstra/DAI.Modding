using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RouteNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<AudioGraphNodeData>> Routes { get; set; }

		public RouteNodeData()
		{
			Routes = new List<ExternalObject<AudioGraphNodeData>>();
		}
	}
}
