using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MoverTune : Asset
	{
		[FieldOffset(12, 72)]
		public float speed { get; set; }

		[FieldOffset(16, 76)]
		public float maxSpeedFraction { get; set; }

		[FieldOffset(20, 80)]
		public ExternalObject<RadiusData> radiusData { get; set; }

		[FieldOffset(24, 88)]
		public float bulk { get; set; }

		[FieldOffset(28, 92)]
		public float cruiseAcc { get; set; }

		[FieldOffset(32, 96)]
		public float startStopAcc { get; set; }

		[FieldOffset(36, 100)]
		public int repulsorType { get; set; }

		[FieldOffset(40, 104)]
		public float flockAcc { get; set; }

		[FieldOffset(44, 108)]
		public float maxFlockAccDist { get; set; }

		[FieldOffset(48, 112)]
		public float pathAcc { get; set; }

		[FieldOffset(52, 120)]
		public ExternalObject<CautionTune> cautionTune { get; set; }

		[FieldOffset(56, 128)]
		public float backpedalFraction { get; set; }

		[FieldOffset(60, 132)]
		public uint planLayer { get; set; }

		[FieldOffset(64, 136)]
		public float pathSharingPenalty { get; set; }

		[FieldOffset(68, 140)]
		public BlockageMode obstacleMode { get; set; }

		[FieldOffset(72, 144)]
		public uint obstacleBlockageFlags { get; set; }

		[FieldOffset(76, 152)]
		public ExternalObject<Dummy> autoObTune { get; set; }

		[FieldOffset(80, 160)]
		public uint repulsorBlockageFlags { get; set; }

		[FieldOffset(84, 164)]
		public uint repulsorIdentityFlags { get; set; }

		[FieldOffset(88, 168)]
		public uint linkUsageFlags { get; set; }

		[FieldOffset(92, 176)]
		public ExternalObject<PathCreationOptions> pathOptions { get; set; }

		[FieldOffset(96, 184)]
		public ExternalObject<Dummy> jumperTune { get; set; }

		[FieldOffset(100, 192)]
		public ExternalObject<Dummy> proberTune { get; set; }

		[FieldOffset(104, 200)]
		public ExternalObject<GoalTune> goalTune { get; set; }

		[FieldOffset(108, 208)]
		public ExternalObject<IdleTune> idleTune { get; set; }

		[FieldOffset(112, 216)]
		public ExternalObject<TurnInPlaceTune> turnInPlace { get; set; }

		[FieldOffset(116, 224)]
		public ExternalObject<RepulsionAccelerationTune> repulsionAccelerationTune { get; set; }

		[FieldOffset(120, 232)]
		public ExternalObject<SurfaceOrientTune> surfaceOrientTune { get; set; }

		[FieldOffset(124, 240)]
		public float sidestepFraction { get; set; }

		[FieldOffset(128, 244)]
		public uint customGeoMatchFlags { get; set; }

		[FieldOffset(132, 248)]
		public ExternalObject<FollowerTune> followerTune { get; set; }

		[FieldOffset(136, 256)]
		public bool exitPuppetInObstacles { get; set; }

		[FieldOffset(137, 257)]
		public bool allowDetour { get; set; }

		[FieldOffset(138, 258)]
		public bool clientMotion { get; set; }
	}
}
