namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_EvaluateConditional : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public ExternalObject<BoolProvider> Value { get; set; }
	}
}
