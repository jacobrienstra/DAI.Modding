namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DuplicateSpawnScopeStageData : SoundScopeStageData
	{
		[FieldOffset(8, 24)]
		public float Time { get; set; }

		[FieldOffset(12, 28)]
		public float Distance { get; set; }

		[FieldOffset(16, 32)]
		public QualityScalableInt ClosestCount { get; set; }

		[FieldOffset(32, 48)]
		public bool GroupTypes { get; set; }
	}
}
