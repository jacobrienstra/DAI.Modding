using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PropertySortScopeStageData : SoundScopeStageData
	{
		[FieldOffset(8, 24)]
		public QualityScalableInt Count { get; set; }

		[FieldOffset(24, 40)]
		public ScopeStageSortProperty Property { get; set; }

		[FieldOffset(28, 44)]
		public PropertySortScopeStageOrder Order { get; set; }

		[FieldOffset(32, 48)]
		public float RangeOfEquality { get; set; }
	}
}
