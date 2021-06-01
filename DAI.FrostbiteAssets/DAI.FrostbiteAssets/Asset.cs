namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Asset : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }
	}
}
