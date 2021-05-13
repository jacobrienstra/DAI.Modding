namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpawnSizeData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float Size { get; set; }
	}
}
