using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EnvironmentDecalVolumeTemplateData : Asset
	{
		[FieldOffset(12, 72)]
		public SurfaceShaderInstanceDataStruct Shader { get; set; }

		[FieldOffset(32, 112)]
		public EnvironmentDecalVolumeMaskType MaskType { get; set; }

		[FieldOffset(36, 116)]
		public QualityScalableFloat CullingDistance { get; set; }

		[FieldOffset(52, 132)]
		public byte SortingPriority { get; set; }
	}
}
