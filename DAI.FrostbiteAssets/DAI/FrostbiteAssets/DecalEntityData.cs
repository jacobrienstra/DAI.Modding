namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DecalEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public DecalAtlasTile AtlasTile { get; set; }

		[FieldOffset(100, 200)]
		public ExternalObject<ShaderGraph> Shader { get; set; }

		[FieldOffset(104, 208)]
		public bool Projected { get; set; }

		[FieldOffset(105, 209)]
		public byte SortingPriority { get; set; }

		[FieldOffset(106, 210)]
		public bool Enabled { get; set; }
	}
}
