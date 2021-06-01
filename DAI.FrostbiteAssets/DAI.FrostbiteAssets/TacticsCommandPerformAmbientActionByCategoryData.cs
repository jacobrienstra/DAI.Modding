using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticsCommandPerformAmbientActionByCategoryData : TacticsCommandData
	{
		[FieldOffset(16, 96)]
		public int SpatialFeature { get; set; }

		[FieldOffset(20, 100)]
		public AmbientActionChooserType ActionChooser { get; set; }

		[FieldOffset(24, 104)]
		public AmbientActionInterruptionType InterruptionCriteria { get; set; }
	}
}
