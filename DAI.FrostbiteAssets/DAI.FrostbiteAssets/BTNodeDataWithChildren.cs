using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BTNodeDataWithChildren : BTNodeData
	{
		[FieldOffset(16, 48)]
		public List<ExternalObject<BTNodeData>> Nodes { get; set; }

		public BTNodeDataWithChildren()
		{
			Nodes = new List<ExternalObject<BTNodeData>>();
		}
	}
}
