namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionCheckHeightDifference : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider_Self> BaseTransform { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<TransformProvider_Partner> TargetTransform { get; set; }

		[FieldOffset(16, 48)]
		public float MinHeight { get; set; }

		[FieldOffset(20, 52)]
		public float MaxHeight { get; set; }
	}
}
