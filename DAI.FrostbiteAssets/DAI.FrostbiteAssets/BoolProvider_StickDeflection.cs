namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_StickDeflection : BoolProvider
	{
		[FieldOffset(8, 32)]
		public float MinValue { get; set; }

		[FieldOffset(12, 36)]
		public float MaxValue { get; set; }
	}
}
