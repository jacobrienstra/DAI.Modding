using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionFloatGameState : BWConditional
	{
		[FieldOffset(8, 32)]
		public AntRef GameStateFloat { get; set; }

		[FieldOffset(28, 80)]
		public FloatGameStateThresholdType Comparison { get; set; }

		[FieldOffset(32, 84)]
		public float Threshold { get; set; }
	}
}
