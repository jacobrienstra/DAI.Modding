namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BehaviorSnippet : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<BehaviorSnippetEvaluationTree> EvaluationTree { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<BehaviorSnippetExecutionTree> ExecutionTree { get; set; }

		[FieldOffset(16, 40)]
		public string DebugName { get; set; }
	}
}
