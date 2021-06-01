using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MeshVariationDatabaseEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<MeshAsset> Mesh { get; set; }

		[FieldOffset(4, 8)]
		public uint VariationAssetNameHash { get; set; }

		[FieldOffset(8, 16)]
		public List<MeshVariationDatabaseMaterial> Materials { get; set; }

		public MeshVariationDatabaseEntry()
		{
			Materials = new List<MeshVariationDatabaseMaterial>();
		}
	}
}
