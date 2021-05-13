namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ZoneStreamerEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public ZoneStreamerInfo Info { get; set; }

		[FieldOffset(112, 224)]
		public bool ClientSideOnly { get; set; }
	}
}
