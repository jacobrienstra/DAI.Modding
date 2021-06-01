namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public ScatterContentSettings ScatterContentSettings { get; set; }
	}
}
