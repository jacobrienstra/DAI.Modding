namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_EvaluateBehaviorTree : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public ExternalObject<BehaviorTreeData> BehaviorTree { get; set; }
	}
}
