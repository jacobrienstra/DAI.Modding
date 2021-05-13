using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConditionNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<ConeOutputNodeData>> Conditions { get; set; }

		public ConditionNodeData()
		{
			Conditions = new List<ExternalObject<ConeOutputNodeData>>();
		}
	}
}
