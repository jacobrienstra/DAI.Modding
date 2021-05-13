using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class MeshProxyEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public ExternalObject<MeshAsset> Mesh { get; set; }

		[FieldOffset(84, 184)]
		public List<LinearTransform> BasePoseTransforms { get; set; }

		[FieldOffset(88, 192)]
		public float CullingBoxScaleFactor { get; set; }

		[FieldOffset(92, 196)]
		public bool StandAloneEnabled { get; set; }

		[FieldOffset(93, 197)]
		public bool DynamicBoundsUpdate { get; set; }

		[FieldOffset(94, 198)]
		public bool UseRootMeshBoneAsWorldTransform { get; set; }

		public MeshProxyEntityData()
		{
			BasePoseTransforms = new List<LinearTransform>();
		}
	}
}
