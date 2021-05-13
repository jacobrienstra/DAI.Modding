namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaxInstancesScopeStageData : SoundScopeStageData
	{
		[FieldOffset(8, 24)]
		public QualityScalableInt Count { get; set; }

		[FieldOffset(24, 40)]
		public bool KeepOldest { get; set; }
	}
}
