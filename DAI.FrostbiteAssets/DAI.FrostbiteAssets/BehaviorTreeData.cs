namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BehaviorTreeData : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<BTNodeData> Root { get; set; }
	}
}
