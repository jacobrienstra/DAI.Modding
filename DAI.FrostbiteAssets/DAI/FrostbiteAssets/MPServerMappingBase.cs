namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingBase : DataContainer
	{
		[FieldOffset(8, 24)]
		public int MPID { get; set; }
	}
}
