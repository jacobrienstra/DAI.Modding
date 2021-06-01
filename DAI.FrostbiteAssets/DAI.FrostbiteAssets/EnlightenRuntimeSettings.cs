namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EnlightenRuntimeSettings : SystemSettings
	{
		[FieldOffset(16, 48)]
		public Vec3 AlbedoDefaultColor { get; set; }

		[FieldOffset(32, 64)]
		public float TemporalCoherenceThreshold { get; set; }

		[FieldOffset(36, 68)]
		public float SkyBoxScale { get; set; }

		[FieldOffset(40, 72)]
		public float MaxPerFrameSolveTime { get; set; }

		[FieldOffset(44, 76)]
		public uint MinSystemUpdateCount { get; set; }

		[FieldOffset(48, 80)]
		public uint JobCount { get; set; }

		[FieldOffset(52, 84)]
		public float CubeMapOcclusionMinScreenArea { get; set; }

		[FieldOffset(56, 88)]
		public uint CubeMapMaxUpdateCount { get; set; }

		[FieldOffset(60, 92)]
		public uint CubeMapConvolutionSampleCount { get; set; }

		[FieldOffset(64, 96)]
		public float CubeMapForceGlobalScale { get; set; }

		[FieldOffset(68, 100)]
		public uint LightProbeMaxSourceSolveCount { get; set; }

		[FieldOffset(72, 104)]
		public uint LightProbeMaxInstanceUpdateCount { get; set; }

		[FieldOffset(76, 108)]
		public uint LightProbeLookupTableGridRes { get; set; }

		[FieldOffset(80, 112)]
		public float LocalLightForceRadius { get; set; }

		[FieldOffset(84, 116)]
		public int DrawDebugMeshLod { get; set; }

		[FieldOffset(88, 120)]
		public int DrawDebugSystemDependenciesEnable { get; set; }

		[FieldOffset(92, 124)]
		public int DrawDebugSystemBoundingBoxEnable { get; set; }

		[FieldOffset(96, 128)]
		public float DrawDebugLightProbeSize { get; set; }

		[FieldOffset(100, 132)]
		public bool Enable { get; set; }

		[FieldOffset(101, 133)]
		public bool ForceDynamic { get; set; }

		[FieldOffset(102, 134)]
		public bool ForceUpdateStaticLightingBuffersEnable { get; set; }

		[FieldOffset(103, 135)]
		public bool SaveRadiosityTexturesEnable { get; set; }

		[FieldOffset(104, 136)]
		public bool JobsEnable { get; set; }

		[FieldOffset(105, 137)]
		public bool ShadowsEnable { get; set; }

		[FieldOffset(106, 138)]
		public bool SpotLightShadowsEnable { get; set; }

		[FieldOffset(107, 139)]
		public bool CubeMapsEnable { get; set; }

		[FieldOffset(108, 140)]
		public bool CubeMapMip0OnlyEnable { get; set; }

		[FieldOffset(109, 141)]
		public bool CubeMapCpuMipMapGenerationEnable { get; set; }

		[FieldOffset(110, 142)]
		public bool CubeMapConvolutionEnable { get; set; }

		[FieldOffset(111, 143)]
		public bool CubeMapFrustumCullEnable { get; set; }

		[FieldOffset(112, 144)]
		public bool CubeMapOcclusionCullEnable { get; set; }

		[FieldOffset(113, 145)]
		public bool CubeMapMinScreenAreaCullEnable { get; set; }

		[FieldOffset(114, 146)]
		public bool CompensateSunShadowHeightScale { get; set; }

		[FieldOffset(115, 147)]
		public bool LightMapsEnable { get; set; }

		[FieldOffset(116, 148)]
		public bool LightProbeEnable { get; set; }

		[FieldOffset(117, 149)]
		public bool LightProbeNewSamplingEnable { get; set; }

		[FieldOffset(118, 150)]
		public bool LightProbeForceUpdate { get; set; }

		[FieldOffset(119, 151)]
		public bool LightProbeJobsEnable { get; set; }

		[FieldOffset(120, 152)]
		public bool LocalLightsEnable { get; set; }

		[FieldOffset(121, 153)]
		public bool LocalLightCullingEnable { get; set; }

		[FieldOffset(122, 154)]
		public bool LocalLightCustumFalloff { get; set; }

		[FieldOffset(123, 155)]
		public bool DrawDebugCubeMaps { get; set; }

		[FieldOffset(124, 156)]
		public bool DrawDebugEntities { get; set; }

		[FieldOffset(125, 157)]
		public bool DrawDebugSystemsEnable { get; set; }

		[FieldOffset(126, 158)]
		public bool DrawDebugLightProbes { get; set; }

		[FieldOffset(127, 159)]
		public bool DrawDebugLightProbeGrid { get; set; }

		[FieldOffset(128, 160)]
		public bool DrawDebugLightProbeOcclusion { get; set; }

		[FieldOffset(129, 161)]
		public bool DrawDebugLightProbeStats { get; set; }

		[FieldOffset(130, 162)]
		public bool DrawDebugLightProbeBoundingBoxes { get; set; }

		[FieldOffset(131, 163)]
		public bool DrawSolveTaskPerformance { get; set; }

		[FieldOffset(132, 164)]
		public bool DrawDebugColoringEnable { get; set; }

		[FieldOffset(133, 165)]
		public bool DrawDebugTextures { get; set; }

		[FieldOffset(134, 166)]
		public bool DrawDebugBackFaces { get; set; }

		[FieldOffset(135, 167)]
		public bool DrawDebugTargetMeshes { get; set; }

		[FieldOffset(136, 168)]
		public bool DrawWarningsEnable { get; set; }

		[FieldOffset(137, 169)]
		public bool AlbedoForceUpdateEnable { get; set; }

		[FieldOffset(138, 170)]
		public bool AlbedoForceColorEnable { get; set; }

		[FieldOffset(139, 171)]
		public bool TerrainMapEnable { get; set; }

		[FieldOffset(140, 172)]
		public bool EmissiveEnable { get; set; }
	}
}
