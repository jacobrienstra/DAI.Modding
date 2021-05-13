using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomEvaluatorData : EvaluatorData
	{
		[FieldOffset(12, 32)]
		public RandomFrequency RandomFrequency { get; set; }

		[FieldOffset(16, 36)]
		public float Max { get; set; }

		[FieldOffset(20, 40)]
		public float Min { get; set; }
	}
}
