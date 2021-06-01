namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class EnlightenDataAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<Dummy> DebugChartTexture { get; set; }

		[FieldOffset(16, 80)]
		public long DatabaseResource { get; set; }

		[FieldOffset(24, 88)]
		public ExternalObject<Dummy> DebugBackFaceTexture { get; set; }

		[FieldOffset(28, 96)]
		public ExternalObject<TextureAsset> SkyVisibilityTexture { get; set; }

		[FieldOffset(32, 104)]
		public uint SystemGridSize { get; set; }

		[FieldOffset(36, 108)]
		public int SystemLightmapSize { get; set; }

		[FieldOffset(40, 112)]
		public int MaxSystemLightmapSize { get; set; }

		[FieldOffset(44, 116)]
		public float SystemInfluenceRadius { get; set; }

		[FieldOffset(48, 120)]
		public float ClusterSize { get; set; }

		[FieldOffset(52, 124)]
		public uint IrBudget { get; set; }

		[FieldOffset(56, 128)]
		public uint IrradianceQualityMultiplier { get; set; }

		[FieldOffset(60, 132)]
		public float VisibilityThreshold { get; set; }

		[FieldOffset(64, 136)]
		public float StitchingDistanceMultiplier { get; set; }

		[FieldOffset(68, 140)]
		public float MaxPixelStitchingAngle { get; set; }

		[FieldOffset(72, 144)]
		public uint SamplesPerCluster { get; set; }

		[FieldOffset(76, 148)]
		public uint MaxCpuThreadCount { get; set; }

		[FieldOffset(80, 152)]
		public uint TerrainProbeRes { get; set; }

		[FieldOffset(84, 156)]
		public uint EnvironmentResolution { get; set; }

		[FieldOffset(88, 160)]
		public bool DynamicEnable { get; set; }

		[FieldOffset(89, 161)]
		public bool LoadDebugData { get; set; }

		[FieldOffset(90, 162)]
		public bool DynamicXenonEnable { get; set; }

		[FieldOffset(91, 163)]
		public bool DynamicPs3Enable { get; set; }

		[FieldOffset(92, 164)]
		public bool DynamicAndroidEnable { get; set; }

		[FieldOffset(93, 165)]
		public bool DynamiciOSEnable { get; set; }

		[FieldOffset(94, 166)]
		public bool DynamicOSXEnable { get; set; }

		[FieldOffset(95, 167)]
		public bool GridBasedSystemGeneration { get; set; }

		[FieldOffset(96, 168)]
		public bool VoxelBasedLeafClustering { get; set; }

		[FieldOffset(97, 169)]
		public bool PixelStitchingEnable { get; set; }

		[FieldOffset(98, 170)]
		public bool EdgeStitchingEnable { get; set; }

		[FieldOffset(99, 171)]
		public bool TerrainEnable { get; set; }
	}
}
