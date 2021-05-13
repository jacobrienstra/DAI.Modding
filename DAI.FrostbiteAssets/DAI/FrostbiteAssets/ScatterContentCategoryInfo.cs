using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentCategoryInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public int Category { get; set; }

		[FieldOffset(4, 8)]
		public string CategoryName { get; set; }

		[FieldOffset(8, 16)]
		public QualityScalableInt MaxSimultaneous { get; set; }

		[FieldOffset(24, 32)]
		public QualityScalableInt MaxVarietySimultaneous { get; set; }

		[FieldOffset(40, 48)]
		public int SpawnPointProbability { get; set; }

		[FieldOffset(44, 52)]
		public float SpawnPointCooldown { get; set; }

		[FieldOffset(48, 56)]
		public ScatterContentReaperNonPersistencePolicy NonPersistencePolicy { get; set; }

		[FieldOffset(52, 60)]
		public QualityScalableInt MaxObjectsToLightPersist { get; set; }

		[FieldOffset(68, 76)]
		public QualityScalableInt MaxObjectsToFullPersist { get; set; }

		[FieldOffset(84, 96)]
		public ExternalObject<ScatterContentTuningOverride> TuningOverride { get; set; }

		[FieldOffset(88, 104)]
		public ScatterContentGameViewOption GameViewOption { get; set; }

		[FieldOffset(92, 108)]
		public bool AllowDisablingOfInnerRadius { get; set; }

		[FieldOffset(93, 109)]
		public bool SpawnPointOccupiedBySpawns { get; set; }
	}
}
