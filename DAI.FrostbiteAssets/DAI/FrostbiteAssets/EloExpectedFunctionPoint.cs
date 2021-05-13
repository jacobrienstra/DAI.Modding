namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EloExpectedFunctionPoint
	{
		[FieldOffset(0, 0)]
		public float XValue { get; set; }

		[FieldOffset(4, 4)]
		public float YValue { get; set; }
	}
}
