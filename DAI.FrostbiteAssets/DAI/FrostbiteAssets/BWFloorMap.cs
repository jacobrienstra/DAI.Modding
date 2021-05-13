namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWFloorMap : LinkObject
	{
		[FieldOffset(0, 0)]
		public int Floor { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<BWMap> AreaMap { get; set; }
	}
}
