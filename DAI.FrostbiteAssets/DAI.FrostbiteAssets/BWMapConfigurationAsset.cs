using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMapConfigurationAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<BWMap> WorldMap { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<BWMapPinCategoryDescription>> CategoryDescriptions { get; set; }

		[FieldOffset(20, 88)]
		public int QuestCategory { get; set; }

		[FieldOffset(24, 92)]
		public int PlotGiverCategory { get; set; }

		[FieldOffset(28, 96)]
		public int CritPathCategory { get; set; }

		[FieldOffset(32, 100)]
		public float UpArrowThreshold { get; set; }

		[FieldOffset(36, 104)]
		public float DownArrowThreshold { get; set; }

		[FieldOffset(40, 108)]
		public float MinVertical { get; set; }

		[FieldOffset(44, 112)]
		public float MinHorizontal { get; set; }

		[FieldOffset(48, 120)]
		public ExternalObject<EffectBlueprint> WaypointVisualEffect { get; set; }

		[FieldOffset(52, 128)]
		public ExternalObject<EffectBlueprint> WaypointReachedVFX { get; set; }

		public BWMapConfigurationAsset()
		{
			CategoryDescriptions = new List<ExternalObject<BWMapPinCategoryDescription>>();
		}
	}
}
