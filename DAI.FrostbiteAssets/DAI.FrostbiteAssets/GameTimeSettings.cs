namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameTimeSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public float JoinJobsTimeLimit { get; set; }

		[FieldOffset(20, 44)]
		public float YieldTimeLimit { get; set; }

		[FieldOffset(24, 48)]
		public int YieldTime { get; set; }

		[FieldOffset(28, 52)]
		public float MaxSimFps { get; set; }

		[FieldOffset(32, 56)]
		public float MaxLoadingFps { get; set; }

		[FieldOffset(36, 60)]
		public uint ForceSimRate { get; set; }

		[FieldOffset(40, 64)]
		public float MaxVariableFps { get; set; }

		[FieldOffset(44, 68)]
		public float MaxInactiveVariableFps { get; set; }

		[FieldOffset(48, 72)]
		public float ForceDeltaTime { get; set; }

		[FieldOffset(52, 76)]
		public int ForceDeltaTickCount { get; set; }

		[FieldOffset(56, 80)]
		public int ClampTicks { get; set; }

		[FieldOffset(60, 84)]
		public float TimeScale { get; set; }

		[FieldOffset(64, 88)]
		public float DebugFrameDelay { get; set; }

		[FieldOffset(68, 92)]
		public bool UseWaitableTimers { get; set; }

		[FieldOffset(69, 93)]
		public bool DoubleNoTickWait { get; set; }

		[FieldOffset(70, 94)]
		public bool VariableSimTickTimeEnable { get; set; }

		[FieldOffset(71, 95)]
		public bool ForceUseSleepTimer { get; set; }

		[FieldOffset(72, 96)]
		public bool ForceSinglePlayerFixedTick { get; set; }

		[FieldOffset(73, 97)]
		public bool ForceMultiplayerOneTickMin { get; set; }

		[FieldOffset(74, 98)]
		public bool EnableSinglePlayerFixedTick { get; set; }
	}
}
