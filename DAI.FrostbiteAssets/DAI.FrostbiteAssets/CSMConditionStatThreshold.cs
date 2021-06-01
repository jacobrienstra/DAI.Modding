using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionStatThreshold : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Entity { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<BWStat> Stat { get; set; }

		[FieldOffset(16, 48)]
		public StatThresholdType CompareType { get; set; }

		[FieldOffset(20, 52)]
		public float Threshold { get; set; }
	}
}
