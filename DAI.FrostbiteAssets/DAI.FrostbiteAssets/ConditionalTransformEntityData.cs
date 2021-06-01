namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ConditionalTransformEntityData : ConditionalStateEntityData
	{
		[FieldOffset(32, 112)]
		public LinearTransform ValueIfTrue { get; set; }

		[FieldOffset(96, 176)]
		public LinearTransform ValueIfFalse { get; set; }
	}
}
