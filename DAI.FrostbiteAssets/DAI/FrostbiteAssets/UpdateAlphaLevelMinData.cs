namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateAlphaLevelMinData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float MinLevel { get; set; }
	}
}
