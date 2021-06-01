namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ServerSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public string InstancePath { get; set; }

		[FieldOffset(20, 48)]
		public uint RemoteControlPort { get; set; }

		[FieldOffset(24, 52)]
		public uint MaxQueriesPerSecond { get; set; }

		[FieldOffset(28, 56)]
		public string SavePoint { get; set; }

		[FieldOffset(32, 64)]
		public float TimeoutTime { get; set; }

		[FieldOffset(36, 68)]
		public uint PlayerCountNeededForMultiplayer { get; set; }

		[FieldOffset(40, 72)]
		public string DebugMenuClick { get; set; }

		[FieldOffset(44, 80)]
		public InternetSimulationSettings IncomingInternetSimulation { get; set; }

		[FieldOffset(124, 160)]
		public InternetSimulationSettings OutgoingInternetSimulation { get; set; }

		[FieldOffset(204, 240)]
		public float LoadingTimeout { get; set; }

		[FieldOffset(208, 244)]
		public float IngameTimeout { get; set; }

		[FieldOffset(212, 248)]
		public float OutgoingFrequency { get; set; }

		[FieldOffset(216, 252)]
		public uint IncomingRate { get; set; }

		[FieldOffset(220, 256)]
		public uint OutgoingRate { get; set; }

		[FieldOffset(224, 264)]
		public string Playlist { get; set; }

		[FieldOffset(228, 272)]
		public int DedicatedServerCpu { get; set; }

		[FieldOffset(232, 276)]
		public uint SaveGameVersion { get; set; }

		[FieldOffset(236, 280)]
		public string ServerName { get; set; }

		[FieldOffset(240, 288)]
		public string ServerPassword { get; set; }

		[FieldOffset(244, 296)]
		public float VehicleSpawnDelayModifier { get; set; }

		[FieldOffset(248, 300)]
		public float HumanHealthMultiplier { get; set; }

		[FieldOffset(252, 304)]
		public float RespawnTimeModifier { get; set; }

		[FieldOffset(256, 312)]
		public string AdministrationPassword { get; set; }

		[FieldOffset(260, 320)]
		public string RemoteAdministrationPort { get; set; }

		[FieldOffset(264, 328)]
		public bool QueryProviderEnabled { get; set; }

		[FieldOffset(265, 329)]
		public bool DebrisClusterEnabled { get; set; }

		[FieldOffset(266, 330)]
		public bool VegetationEnabled { get; set; }

		[FieldOffset(267, 331)]
		public bool WaterPhysicsEnabled { get; set; }

		[FieldOffset(268, 332)]
		public bool IsDesertingAllowed { get; set; }

		[FieldOffset(269, 333)]
		public bool IsRenderDamageEvents { get; set; }

		[FieldOffset(270, 334)]
		public bool RespawnOnDeathPosition { get; set; }

		[FieldOffset(271, 335)]
		public bool IsStatsEnabled { get; set; }

		[FieldOffset(272, 336)]
		public bool IsNetworkStatsEnabled { get; set; }

		[FieldOffset(273, 337)]
		public bool IsAiEnabled { get; set; }

		[FieldOffset(274, 338)]
		public bool IsDestructionEnabled { get; set; }

		[FieldOffset(275, 339)]
		public bool IsSoldierAnimationEnabled { get; set; }

		[FieldOffset(276, 340)]
		public bool IsSoldierDetailedCollisionEnabled { get; set; }

		[FieldOffset(277, 341)]
		public bool LoadSavePoint { get; set; }

		[FieldOffset(278, 342)]
		public bool DisableCutscenes { get; set; }

		[FieldOffset(279, 343)]
		public bool HavokVisualDebugger { get; set; }

		[FieldOffset(280, 344)]
		public bool HavokCaptureToFile { get; set; }

		[FieldOffset(281, 345)]
		public bool ShowTriggerDebugText { get; set; }

		[FieldOffset(282, 346)]
		public bool TimeoutGame { get; set; }

		[FieldOffset(283, 347)]
		public bool AILooksIntoCamera { get; set; }

		[FieldOffset(284, 348)]
		public bool DeathmatchDebugInfo { get; set; }

		[FieldOffset(285, 349)]
		public bool UseDebugSocket { get; set; }

		[FieldOffset(286, 350)]
		public bool OverrideRemoteInternetSimulation { get; set; }

		[FieldOffset(287, 351)]
		public bool AllowOverrideInternetSimulation { get; set; }

		[FieldOffset(288, 352)]
		public bool JobEnable { get; set; }

		[FieldOffset(289, 353)]
		public bool ThreadingEnable { get; set; }

		[FieldOffset(290, 354)]
		public bool DrawActivePhysicsObjects { get; set; }

		[FieldOffset(291, 355)]
		public bool IsRanked { get; set; }

		[FieldOffset(292, 356)]
		public bool UnlockResolver { get; set; }

		[FieldOffset(293, 357)]
		public bool ScoringLogEnabled { get; set; }

		[FieldOffset(294, 358)]
		public bool ForcePlaylist { get; set; }

		[FieldOffset(295, 359)]
		public bool AutoUnspawnBangers { get; set; }

		[FieldOffset(296, 360)]
		public bool RegulatedAIThrottle { get; set; }

		[FieldOffset(297, 361)]
		public bool EnableAnimationCulling { get; set; }

		[FieldOffset(298, 362)]
		public bool FallBackToSquadSpawn { get; set; }

		[FieldOffset(299, 363)]
		public bool SaveGameUseProfileSaves { get; set; }

		[FieldOffset(300, 364)]
		public bool VehicleSpawnAllowed { get; set; }

		[FieldOffset(301, 365)]
		public bool AdministrationEnabled { get; set; }

		[FieldOffset(302, 366)]
		public bool AdministrationLogEnabled { get; set; }

		[FieldOffset(303, 367)]
		public bool AdministrationTimeStampLogNames { get; set; }

		[FieldOffset(304, 368)]
		public bool AdministrationEventsEnabled { get; set; }

		[FieldOffset(305, 369)]
		public bool AdministrationServerNameRestricted { get; set; }
	}
}
