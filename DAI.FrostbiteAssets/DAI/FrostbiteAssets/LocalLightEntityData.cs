namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LocalLightEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public bool Enabled { get; set; }
	}
}
