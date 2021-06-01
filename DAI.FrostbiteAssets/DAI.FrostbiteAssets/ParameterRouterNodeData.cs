using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ParameterRouterNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort RouteIn { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort RouteOut { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort DefaultOut { get; set; }

		[FieldOffset(32, 144)]
		public List<ExternalObject<OutputNodeData>> ParameterRouterEntries { get; set; }

		public ParameterRouterNodeData()
		{
			ParameterRouterEntries = new List<ExternalObject<OutputNodeData>>();
		}
	}
}
