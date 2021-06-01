using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SubWorldData : SpatialPrefabBlueprint
	{
		[FieldOffset(40, 200)]
		public ExternalObject<MaterialGridData> RuntimeMaterialGrid { get; set; }

		[FieldOffset(44, 208)]
		public BlueprintPersistenceSetting PersistenceSetting { get; set; }

		[FieldOffset(48, 216)]
		public ExternalObject<AutoAssetCollector> AutoAssetCollector { get; set; }

		[FieldOffset(52, 224)]
		public bool IsWin32SubLevel { get; set; }

		[FieldOffset(53, 225)]
		public bool IsXenonSubLevel { get; set; }

		[FieldOffset(54, 226)]
		public bool IsPs3SubLevel { get; set; }

		[FieldOffset(55, 227)]
		public bool IsGen4aSubLevel { get; set; }

		[FieldOffset(56, 228)]
		public bool IsGen4bSubLevel { get; set; }

		[FieldOffset(57, 229)]
		public bool IsAndroidSubLevel { get; set; }

		[FieldOffset(58, 230)]
		public bool IsIOSSubLevel { get; set; }

		[FieldOffset(59, 231)]
		public bool IsOSXSubLevel { get; set; }

		[FieldOffset(60, 232)]
		public bool TriggerSublevelScrubCheckpoint { get; set; }
	}
}
