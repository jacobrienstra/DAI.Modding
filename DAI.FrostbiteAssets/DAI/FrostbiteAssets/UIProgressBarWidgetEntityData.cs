using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIProgressBarWidgetEntityData : UIMaskingWidgetEntityData
	{
		[FieldOffset(112, 240)]
		public float MinimumNonZeroPercentage { get; set; }

		[FieldOffset(116, 244)]
		public UIProgressBarWidget_GrowthDirection GrowthDirection { get; set; }

		[FieldOffset(120, 248)]
		public float StartPercentage { get; set; }

		[FieldOffset(124, 252)]
		public float EndPercentage { get; set; }

		[FieldOffset(128, 256)]
		public bool IgnoreBoundsAtEndLimit { get; set; }
	}
}
