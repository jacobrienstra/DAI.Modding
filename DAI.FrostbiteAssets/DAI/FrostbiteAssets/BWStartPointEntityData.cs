namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWStartPointEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public int ID { get; set; }
	}
}
