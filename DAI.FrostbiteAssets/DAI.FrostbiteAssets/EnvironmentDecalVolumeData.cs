namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EnvironmentDecalVolumeData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public ExternalObject<EnvironmentDecalVolumeTemplateData> Template { get; set; }

		[FieldOffset(84, 184)]
		public QualityScalableFloat CullingDistance { get; set; }

		[FieldOffset(100, 200)]
		public float OverrideTemplateCullingDistance { get; set; }

		[FieldOffset(104, 204)]
		public float Alpha { get; set; }

		[FieldOffset(108, 208)]
		public bool IsEnabled { get; set; }

		[FieldOffset(109, 209)]
		public byte Row { get; set; }

		[FieldOffset(110, 210)]
		public byte Column { get; set; }
	}
}
