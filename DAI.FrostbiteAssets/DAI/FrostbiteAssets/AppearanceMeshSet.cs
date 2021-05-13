using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AppearanceMeshSet : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<MeshAsset>> Meshes { get; set; }

		[FieldOffset(16, 80)]
		public int SortIndex { get; set; }

		[FieldOffset(20, 88)]
		public List<VariationLink> VariationLinks { get; set; }

		[FieldOffset(24, 96)]
		public bool CombatOnly { get; set; }

		[FieldOffset(25, 97)]
		public bool ProvidesBounds { get; set; }

		public AppearanceMeshSet()
		{
			Meshes = new List<ExternalObject<MeshAsset>>();
			VariationLinks = new List<VariationLink>();
		}
	}
}
