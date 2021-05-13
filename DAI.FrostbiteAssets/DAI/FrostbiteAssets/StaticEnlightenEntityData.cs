namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StaticEnlightenEntityData : EnlightenEntityData
	{
		[FieldOffset(28, 112)]
		public ExternalObject<StaticEnlightenData> EnlightenData { get; set; }

		[FieldOffset(32, 120)]
		public ExternalObject<EnlightenDataAsset> DynamicEnlightenData { get; set; }

		[FieldOffset(36, 128)]
		public ExternalObject<VisualEnvironmentBlueprint> VisualEnvironment { get; set; }

		[FieldOffset(40, 136)]
		public bool RequiresRayTracedSpotLightShadows { get; set; }

		[FieldOffset(41, 137)]
		public bool DisableSpotLightRayTracing { get; set; }
	}
}
