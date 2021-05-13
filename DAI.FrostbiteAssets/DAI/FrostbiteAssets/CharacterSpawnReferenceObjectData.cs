namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CharacterSpawnReferenceObjectData : SpawnReferenceObjectData
	{
		[FieldOffset(352, 512)]
		public uint VehicleEntryIndex { get; set; }

		[FieldOffset(356, 516)]
		public float HumanTargetPreference { get; set; }

		[FieldOffset(360, 520)]
		public int MenuShowOrder { get; set; }

		[FieldOffset(364, 524)]
		public bool AllowFallbackOnNextAvailabeVehicleEntry { get; set; }

		[FieldOffset(365, 525)]
		public bool SpawnVisible { get; set; }

		[FieldOffset(366, 526)]
		public bool IsTarget { get; set; }

		[FieldOffset(367, 527)]
		public bool AffectMinimapPosition { get; set; }

		[FieldOffset(368, 528)]
		public bool ShowAsLabelOnly { get; set; }

		[FieldOffset(369, 529)]
		public bool ShowInMenu { get; set; }
	}
}
