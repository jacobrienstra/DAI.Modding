namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class WaterInteractEntityData : GamePhysicsEntityData
	{
		[FieldOffset(128, 240)]
		public Vec3 TileOffset { get; set; }

		[FieldOffset(144, 256)]
		public AmbientWaveSettings AmbientWaveSettings { get; set; }

		[FieldOffset(400, 608)]
		public AmbientWaveSettings DetailWaveSettings { get; set; }

		[FieldOffset(656, 960)]
		public ExternalObject<ShaderGraph> Shader { get; set; }

		[FieldOffset(660, 968)]
		public float ProjectorElevation { get; set; }

		[FieldOffset(664, 972)]
		public float WaveAmplitudeScale { get; set; }

		[FieldOffset(668, 976)]
		public float Choppiness { get; set; }

		[FieldOffset(672, 980)]
		public float TileDimension { get; set; }

		[FieldOffset(676, 984)]
		public QualityScalableInt SimulationResolution { get; set; }

		[FieldOffset(692, 1000)]
		public float DetailTileDimension { get; set; }

		[FieldOffset(696, 1004)]
		public QualityScalableInt DetailSimulationResolution { get; set; }

		[FieldOffset(712, 1024)]
		public ExternalObject<Dummy> EffectSetup { get; set; }

		[FieldOffset(716, 1032)]
		public float ShoreWaveAmplitude { get; set; }

		[FieldOffset(720, 1036)]
		public float ShoreWaveFrequency { get; set; }

		[FieldOffset(724, 1040)]
		public float ShoreWindAngle { get; set; }

		[FieldOffset(728, 1044)]
		public float ShoreWindWavelength { get; set; }

		[FieldOffset(732, 1048)]
		public float ShoreWavelength { get; set; }

		[FieldOffset(736, 1052)]
		public float ShoreDepth { get; set; }

		[FieldOffset(740, 1056)]
		public MaterialDecl MaterialPair { get; set; }

		[FieldOffset(744, 1072)]
		public QualityScalableInt InteractiveWavesGridCount { get; set; }

		[FieldOffset(760, 1088)]
		public QualityScalableInt InteractiveWavesCellCount { get; set; }

		[FieldOffset(776, 1104)]
		public float InteractiveWaveDisturbanceScale { get; set; }

		[FieldOffset(780, 1112)]
		public ExternalObject<Dummy> InteractiveFoamSplatTexture { get; set; }

		[FieldOffset(784, 1120)]
		public float InteractiveFoamHalfLife { get; set; }

		[FieldOffset(788, 1124)]
		public float InteractiveFoamTargetScale { get; set; }

		[FieldOffset(792, 1128)]
		public float InteractiveFoamSplatInterval { get; set; }

		[FieldOffset(796, 1132)]
		public WaterEntityClipInfo ClipInfo { get; set; }

		[FieldOffset(801, 1137)]
		public bool WaveSimulation { get; set; }

		[FieldOffset(802, 1138)]
		public bool Visible { get; set; }

		[FieldOffset(803, 1139)]
		public QualityScalableBool DetailSimulation { get; set; }

		[FieldOffset(807, 1143)]
		public bool ShorelineEnable { get; set; }

		[FieldOffset(808, 1144)]
		public QualityScalableBool InteractiveWavesEnable { get; set; }
	}
}
