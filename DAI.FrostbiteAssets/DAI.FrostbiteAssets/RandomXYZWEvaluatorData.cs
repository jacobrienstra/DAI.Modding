using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomXYZWEvaluatorData : EvaluatorData
	{
		[FieldOffset(12, 32)]
		public RandomFrequency RandomFrequency { get; set; }

		[FieldOffset(16, 36)]
		public float MaxX { get; set; }

		[FieldOffset(20, 40)]
		public float MinX { get; set; }

		[FieldOffset(24, 44)]
		public float MaxY { get; set; }

		[FieldOffset(28, 48)]
		public float MinY { get; set; }

		[FieldOffset(32, 52)]
		public float MaxZ { get; set; }

		[FieldOffset(36, 56)]
		public float MinZ { get; set; }

		[FieldOffset(40, 60)]
		public float MaxW { get; set; }

		[FieldOffset(44, 64)]
		public float MinW { get; set; }
	}
}
