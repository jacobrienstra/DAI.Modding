namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MeshVariationDatabaseRedirectEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<MeshAsset> Mesh { get; set; }

		[FieldOffset(4, 8)]
		public uint VariationAssetNameHash { get; set; }
	}
}
