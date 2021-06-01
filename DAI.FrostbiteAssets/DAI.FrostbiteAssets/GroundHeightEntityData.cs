namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GroundHeightEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public GroundHeightData Data { get; set; }
	}
}
