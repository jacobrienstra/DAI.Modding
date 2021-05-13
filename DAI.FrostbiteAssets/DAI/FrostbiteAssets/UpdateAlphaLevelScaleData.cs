namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateAlphaLevelScaleData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float Exponent { get; set; }
	}
}
