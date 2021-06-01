namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConditionalFloatEntityData : ConditionalStateEntityData
	{
		[FieldOffset(24, 104)]
		public float ValueIfTrue { get; set; }

		[FieldOffset(28, 108)]
		public float ValueIfFalse { get; set; }
	}
}
