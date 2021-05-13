namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BTRefTreeNode : BTNodeData
	{
		[FieldOffset(16, 48)]
		public ExternalObject<BehaviorTreeData> SubTree { get; set; }
	}
}
