namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionCheckTether : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider_Self> Entity { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<TransformProvider> Transform { get; set; }

		[FieldOffset(16, 48)]
		public bool NoTransformReturn { get; set; }
	}
}
