namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UILoadingWidgetEntityData : UIWidgetEntityData
	{
		[FieldOffset(68, 184)]
		public float BackgroundChangeDelaySec { get; set; }

		[FieldOffset(72, 188)]
		public float BackgroundFadeSpeedSec { get; set; }

		[FieldOffset(76, 192)]
		public uint MaxTipsToShow { get; set; }

		[FieldOffset(80, 196)]
		public float TipCardIntroDurationSec { get; set; }

		[FieldOffset(84, 200)]
		public float TipCardSwitchDurationSec { get; set; }

		[FieldOffset(88, 204)]
		public float TipCardAnimationDistance { get; set; }

		[FieldOffset(92, 208)]
		public float AnimationEaseInExponent { get; set; }

		[FieldOffset(96, 212)]
		public float TipCardAnimationMinAlpha { get; set; }

		[FieldOffset(100, 216)]
		public float TipCardControlsDisabledPercentageGrey { get; set; }

		[FieldOffset(104, 220)]
		public float TipTextScrollDistance { get; set; }

		[FieldOffset(108, 224)]
		public float TipTextScrollDurationPerInputTick { get; set; }

		[FieldOffset(112, 228)]
		public float TipTextMouseWheelStepDistance { get; set; }

		[FieldOffset(116, 232)]
		public float TipTextScrollDurationPerWheelStep { get; set; }

		[FieldOffset(120, 240)]
		public ExternalObject<Dummy> NavigationSound { get; set; }
	}
}
