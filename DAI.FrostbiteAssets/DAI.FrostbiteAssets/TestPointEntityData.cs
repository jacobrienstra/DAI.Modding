namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TestPointEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public string OutputName { get; set; }
	}
}
