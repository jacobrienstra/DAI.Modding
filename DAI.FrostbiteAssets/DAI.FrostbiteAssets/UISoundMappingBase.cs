namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISoundMappingBase : DataContainer
	{
		[FieldOffset(8, 24)]
		public bool Enable { get; set; }
	}
}
