namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DefaultEvaluatorData : EvaluatorData
	{
		[FieldOffset(16, 32)]
		public Vec4 Values { get; set; }
	}
}
