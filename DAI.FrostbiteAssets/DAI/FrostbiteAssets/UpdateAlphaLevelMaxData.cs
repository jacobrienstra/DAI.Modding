namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateAlphaLevelMaxData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float MaxLevel { get; set; }
	}
}
