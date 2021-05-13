using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_HasLineOfSight : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(20, 44)]
		public float TargetToleranceDistance { get; set; }

		[FieldOffset(24, 48)]
		public ExternalObject<FloatProvider> LOSTestHeight { get; set; }

		[FieldOffset(28, 56)]
		public bool CheckFieldOfView { get; set; }
	}
}
