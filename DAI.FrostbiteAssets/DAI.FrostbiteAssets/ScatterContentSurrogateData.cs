namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentSurrogateData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public int Category { get; set; }
	}
}
