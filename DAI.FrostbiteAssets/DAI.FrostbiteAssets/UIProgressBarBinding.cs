using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIProgressBarBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public ProgressBarAnim Animation { get; set; }

		[FieldOffset(12, 28)]
		public ProgressBarEasing Easing { get; set; }

		[FieldOffset(16, 32)]
		public float AnimationTime { get; set; }

		[FieldOffset(20, 36)]
		public float AnimDelay { get; set; }

		[FieldOffset(24, 40)]
		public string BarId { get; set; }

		[FieldOffset(28, 48)]
		public float MinimumValue { get; set; }

		[FieldOffset(32, 52)]
		public float MaximumValue { get; set; }

		[FieldOffset(36, 56)]
		public float StartingValue { get; set; }

		[FieldOffset(40, 64)]
		public UIDataSourceInfo ProgressBarData { get; set; }
	}
}
