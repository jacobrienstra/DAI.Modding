using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LevelData : WorldData
	{
		[FieldOffset(68, 360)]
		public ExternalObject<PathfindingBlobAsset> PathfindingBlobs { get; set; }

		[FieldOffset(72, 368)]
		public ExternalObject<Dummy> AISystem { get; set; }

		[FieldOffset(76, 376)]
		public ExternalObject<Dummy> AI2System { get; set; }

		[FieldOffset(80, 384)]
		public float WorldSizeXZ { get; set; }

		[FieldOffset(84, 392)]
		public LevelDescription LevelDescription { get; set; }

		[FieldOffset(100, 424)]
		public string GameConfigurationName { get; set; }

		[FieldOffset(104, 432)]
		public float DefaultFOV { get; set; }

		[FieldOffset(108, 436)]
		public float InfantryFOVMultiplier { get; set; }

		[FieldOffset(112, 440)]
		public ExternalObject<Dummy> StreamPoolPreset { get; set; }

		[FieldOffset(116, 448)]
		public ExternalObject<Dummy> VoiceOverSystem { get; set; }

		[FieldOffset(120, 456)]
		public List<ExternalObject<StaticModelGroupEntityData>> VoiceOverLogic { get; set; }

		[FieldOffset(124, 464)]
		public float MaxVehicleHeight { get; set; }

		[FieldOffset(128, 472)]
		public ExternalObject<EnlightenShaderDatabaseAsset> EnlightenShaderDatabase { get; set; }

		[FieldOffset(132, 480)]
		public ExternalObject<AntProjectAsset> AntProjectAsset { get; set; }

		[FieldOffset(136, 488)]
		public string AerialHeightmapData { get; set; }

		[FieldOffset(140, 496)]
		public List<ExternalObject<GameObjectData>> CameraModes { get; set; }

		[FieldOffset(144, 504)]
		public List<ExternalObject<GameObjectData>> CameraTransitions { get; set; }

		[FieldOffset(148, 512)]
		public LevelPreloadInfo PreloadInfo { get; set; }

		[FieldOffset(156, 528)]
		public ExternalObject<Dummy> FaceAnimationWaveMappings { get; set; }

		[FieldOffset(160, 536)]
		public List<uint> AutoLoadBundleHashes { get; set; }

		[FieldOffset(164, 544)]
		public UnlockIdTable UnlockIdTable { get; set; }

		[FieldOffset(168, 552)]
		public List<SharedBundleReferenceInfo> AllSharedBundles { get; set; }

		[FieldOffset(172, 560)]
		public List<BlueprintBundleReferenceInfo> AllBlueprintBundles { get; set; }

		[FieldOffset(176, 568)]
		public List<SubLevelBundleReferenceInfo> AllSubLevels { get; set; }

		[FieldOffset(180, 576)]
		public bool HugeBroadPhase { get; set; }

		[FieldOffset(181, 577)]
		public bool FreeStreamingEnable { get; set; }

		public LevelData()
		{
			VoiceOverLogic = new List<ExternalObject<StaticModelGroupEntityData>>();
			CameraModes = new List<ExternalObject<GameObjectData>>();
			CameraTransitions = new List<ExternalObject<GameObjectData>>();
			AutoLoadBundleHashes = new List<uint>();
			AllSharedBundles = new List<SharedBundleReferenceInfo>();
			AllBlueprintBundles = new List<BlueprintBundleReferenceInfo>();
			AllSubLevels = new List<SubLevelBundleReferenceInfo>();
		}
	}
}
