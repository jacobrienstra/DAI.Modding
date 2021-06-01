using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class MeshAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<MeshLodGroup> LodGroup { get; set; }

		[FieldOffset(16, 80)]
		public long MeshSetResource { get; set; }

		[FieldOffset(24, 88)]
		public long OccluderMeshResource { get; set; }

		[FieldOffset(32, 96)]
		public float LodScale { get; set; }

		[FieldOffset(36, 100)]
		public float CullScale { get; set; }

		[FieldOffset(40, 104)]
		public float CoverageValue { get; set; }

		[FieldOffset(44, 108)]
		public EnlightenType EnlightenType { get; set; }

		[FieldOffset(48, 112)]
		public int EnlightenMeshLod { get; set; }

		[FieldOffset(52, 116)]
		public float AutoLightmapUVsMaxDistance { get; set; }

		[FieldOffset(56, 120)]
		public float AutoLightmapUVsExpansionFactor { get; set; }

		[FieldOffset(60, 128)]
		public ExternalObject<ProceduralAnimationTypeSimple> ProceduralAnimation { get; set; }

		[FieldOffset(64, 136)]
		public List<ExternalObject<MeshMaterial>> Materials { get; set; }

		[FieldOffset(68, 144)]
		public uint NameHash { get; set; }

		[FieldOffset(72, 148)]
		public bool StreamingEnable { get; set; }

		[FieldOffset(73, 149)]
		public bool OccluderMeshEnable { get; set; }

		[FieldOffset(74, 150)]
		public bool OccluderHighPriority { get; set; }

		[FieldOffset(75, 151)]
		public bool OccluderIsConservative { get; set; }

		[FieldOffset(76, 152)]
		public bool DestructionMaterialEnable { get; set; }

		[FieldOffset(77, 153)]
		public bool LightmapUVsScaleCharts { get; set; }

		[FieldOffset(78, 154)]
		public bool AutoLightmapUVs { get; set; }

		public MeshAsset()
		{
			Materials = new List<ExternalObject<MeshMaterial>>();
		}
	}
}
