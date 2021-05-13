using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MeshMaterial : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<SurfaceShaderInstanceData> ShaderInstance { get; set; }

		[FieldOffset(12, 32)]
		public SurfaceShaderInstanceDataStruct Shader { get; set; }

		[FieldOffset(32, 72)]
		public ShaderTessellationType TessellationType { get; set; }

		[FieldOffset(36, 76)]
		public float TessellationTriangleSize { get; set; }

		[FieldOffset(40, 80)]
		public float TessellationMaxDistance { get; set; }

		[FieldOffset(44, 84)]
		public float BackFaceCullEpsilon { get; set; }

		[FieldOffset(48, 88)]
		public float ShapeFactor { get; set; }

		[FieldOffset(52, 96)]
		public ExternalObject<TextureAsset> DisplacementMap { get; set; }

		[FieldOffset(56, 104)]
		public float DisplacementScale { get; set; }

		[FieldOffset(60, 108)]
		public float DisplacementBias { get; set; }

		[FieldOffset(64, 112)]
		public uint DisplacementMapTexCoord { get; set; }

		[FieldOffset(68, 116)]
		public QualityScalableBool TessellationEnable { get; set; }

		[FieldOffset(72, 120)]
		public bool SmoothEdgeVertices { get; set; }

		[FieldOffset(73, 121)]
		public bool DisplacementObjectScale { get; set; }

		[FieldOffset(74, 122)]
		public bool PatchEdgeSeams { get; set; }
	}
}
