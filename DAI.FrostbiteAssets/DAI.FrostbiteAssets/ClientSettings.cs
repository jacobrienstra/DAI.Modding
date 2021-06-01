namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClientSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public uint VrDeviceType { get; set; }

		[FieldOffset(20, 44)]
		public float JuiceDistanceThreshold { get; set; }

		[FieldOffset(24, 48)]
		public float JuiceTimeThreshold { get; set; }

		[FieldOffset(28, 52)]
		public float JuiceVehicleDistanceThreshold { get; set; }

		[FieldOffset(32, 56)]
		public float JuiceVehicleTimeThreshold { get; set; }

		[FieldOffset(36, 64)]
		public string ScreenshotFilename { get; set; }

		[FieldOffset(40, 72)]
		public string ScreenshotSuffix { get; set; }

		[FieldOffset(44, 80)]
		public uint Team { get; set; }

		[FieldOffset(48, 84)]
		public int SpawnPointIndex { get; set; }

		[FieldOffset(52, 88)]
		public string ServerIp { get; set; }

		[FieldOffset(56, 96)]
		public string SecondaryServerIp { get; set; }

		[FieldOffset(60, 104)]
		public float AimScale { get; set; }

		[FieldOffset(64, 108)]
		public float MouseSensitivityMin { get; set; }

		[FieldOffset(68, 112)]
		public float MouseSensitivitySliderRange { get; set; }

		[FieldOffset(72, 116)]
		public float MouseSensitivityFactor { get; set; }

		[FieldOffset(76, 120)]
		public float MouseSensitivityPower { get; set; }

		[FieldOffset(80, 124)]
		public float XenonGamepadDeadZoneCenter { get; set; }

		[FieldOffset(84, 128)]
		public float XenonGamepadDeadZoneAxis { get; set; }

		[FieldOffset(88, 132)]
		public float XenonGamepadDeadZoneOffsetAxis { get; set; }

		[FieldOffset(92, 136)]
		public float PS3GamepadDeadZoneCenter { get; set; }

		[FieldOffset(96, 140)]
		public float PS3GamepadDeadZoneAxis { get; set; }

		[FieldOffset(100, 144)]
		public float PS3GamepadDeadZoneOffsetAxis { get; set; }

		[FieldOffset(104, 148)]
		public float PCGamepadDeadZoneCenter { get; set; }

		[FieldOffset(108, 152)]
		public float PCGamepadDeadZoneAxis { get; set; }

		[FieldOffset(112, 156)]
		public float PCGamepadDeadZoneOffsetAxis { get; set; }

		[FieldOffset(116, 160)]
		public float Gen4aGamepadDeadZoneCenter { get; set; }

		[FieldOffset(120, 164)]
		public float Gen4aGamepadDeadZoneAxis { get; set; }

		[FieldOffset(124, 168)]
		public float Gen4aGamepadDeadZoneOffsetAxis { get; set; }

		[FieldOffset(128, 172)]
		public float Gen4bGamepadDeadZoneCenter { get; set; }

		[FieldOffset(132, 176)]
		public float Gen4bGamepadDeadZoneAxis { get; set; }

		[FieldOffset(136, 180)]
		public float Gen4bGamepadDeadZoneOffsetAxis { get; set; }

		[FieldOffset(140, 184)]
		public InternetSimulationSettings IncomingInternetSimulation { get; set; }

		[FieldOffset(220, 264)]
		public InternetSimulationSettings OutgoingInternetSimulation { get; set; }

		[FieldOffset(300, 344)]
		public string GamepadGuid { get; set; }

		[FieldOffset(304, 352)]
		public float IncomingFrequency { get; set; }

		[FieldOffset(308, 356)]
		public uint IncomingRate { get; set; }

		[FieldOffset(312, 360)]
		public uint OutgoingRate { get; set; }

		[FieldOffset(316, 364)]
		public float LoadingTimeout { get; set; }

		[FieldOffset(320, 368)]
		public float LoadedTimeout { get; set; }

		[FieldOffset(324, 372)]
		public float IngameTimeout { get; set; }

		[FieldOffset(328, 376)]
		public float CpuQuality { get; set; }

		[FieldOffset(332, 380)]
		public bool IsSpectator { get; set; }

		[FieldOffset(333, 381)]
		public bool VsyncEnable { get; set; }

		[FieldOffset(334, 382)]
		public bool VisualFrameInterpolation { get; set; }

		[FieldOffset(335, 383)]
		public bool DebrisClusterEnabled { get; set; }

		[FieldOffset(336, 384)]
		public bool VegetationEnabled { get; set; }

		[FieldOffset(337, 385)]
		public bool ForceEnabled { get; set; }

		[FieldOffset(338, 386)]
		public bool WorldRenderEnabled { get; set; }

		[FieldOffset(339, 387)]
		public bool TerrainEnabled { get; set; }

		[FieldOffset(340, 388)]
		public bool WaterPhysicsEnabled { get; set; }

		[FieldOffset(341, 389)]
		public bool OvergrowthEnabled { get; set; }

		[FieldOffset(342, 390)]
		public bool EffectsEnabled { get; set; }

		[FieldOffset(343, 391)]
		public bool EmittersEnabled { get; set; }

		[FieldOffset(344, 392)]
		public bool PadRumbleEnabled { get; set; }

		[FieldOffset(345, 393)]
		public bool JuicePlayerReportPositionEnabled { get; set; }

		[FieldOffset(346, 394)]
		public bool LipSyncEnabled { get; set; }

		[FieldOffset(347, 395)]
		public bool OnDamageSpottingEnabled { get; set; }

		[FieldOffset(348, 396)]
		public bool IgnoreClientFireRateMultiplier { get; set; }

		[FieldOffset(349, 397)]
		public bool PauseGameOnStartUp { get; set; }

		[FieldOffset(350, 398)]
		public bool SkipFastLevelLoad { get; set; }

		[FieldOffset(351, 399)]
		public bool InputEnable { get; set; }

		[FieldOffset(352, 400)]
		public bool ScreenshotToFile { get; set; }

		[FieldOffset(353, 401)]
		public bool LoadMenu { get; set; }

		[FieldOffset(354, 402)]
		public bool DebugMenuOnLThumb { get; set; }

		[FieldOffset(355, 403)]
		public bool InvertFreeCamera { get; set; }

		[FieldOffset(356, 404)]
		public bool RenderTags { get; set; }

		[FieldOffset(357, 405)]
		public bool InvertPitch { get; set; }

		[FieldOffset(358, 406)]
		public bool InvertPadPcRightStick { get; set; }

		[FieldOffset(359, 407)]
		public bool Scheme0FlipY { get; set; }

		[FieldOffset(360, 408)]
		public bool Scheme1FlipY { get; set; }

		[FieldOffset(361, 409)]
		public bool Scheme2FlipY { get; set; }

		[FieldOffset(362, 410)]
		public bool InvertYaw { get; set; }

		[FieldOffset(363, 411)]
		public bool ConsoleInputEmulation { get; set; }

		[FieldOffset(364, 412)]
		public bool SampleInputEveryVisualFrame { get; set; }

		[FieldOffset(365, 413)]
		public bool UseDebugSocket { get; set; }

		[FieldOffset(366, 414)]
		public bool OverrideRemoteInternetSimulation { get; set; }

		[FieldOffset(367, 415)]
		public bool AllowOverrideInternetSimulation { get; set; }

		[FieldOffset(368, 416)]
		public bool HavokVisualDebugger { get; set; }

		[FieldOffset(369, 417)]
		public bool HavokVDBShowsEffectsWorld { get; set; }

		[FieldOffset(370, 418)]
		public bool HavokCaptureToFile { get; set; }

		[FieldOffset(371, 419)]
		public bool EnforceXInputCompatibility { get; set; }

		[FieldOffset(372, 420)]
		public bool UseMouseAndKeyboardSystem { get; set; }

		[FieldOffset(373, 421)]
		public bool UseGlobalGamePadInput { get; set; }

		[FieldOffset(374, 422)]
		public bool ShowBuildId { get; set; }

		[FieldOffset(375, 423)]
		public bool ExtractPersistenceInformation { get; set; }

		[FieldOffset(376, 424)]
		public bool EnableRestTool { get; set; }

		[FieldOffset(377, 425)]
		public bool LocalVehicleSimulationEnabled { get; set; }

		[FieldOffset(378, 426)]
		public bool AsyncClientBulletEntity { get; set; }

		[FieldOffset(379, 427)]
		public bool AutoUnspawnDynamicObjects { get; set; }

		[FieldOffset(380, 428)]
		public bool QuitGameOnServerDisconnect { get; set; }

		[FieldOffset(381, 429)]
		public bool DebugTrackAllPlayersInSpawnScreen { get; set; }

		[FieldOffset(382, 430)]
		public bool UseOldKillerCamera { get; set; }

		[FieldOffset(383, 431)]
		public bool LuaOptionSetEnable { get; set; }

		[FieldOffset(384, 432)]
		public bool DamageFloatiesEnabled { get; set; }

		[FieldOffset(385, 433)]
		public bool TargetLockIsToggle { get; set; }

		[FieldOffset(386, 434)]
		public bool EnvironmentDecalVolumesEnabled { get; set; }
	}
}
