namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UI3dIconCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public float IconSize { get; set; }

		[FieldOffset(36, 140)]
		public float SnapSafeZone { get; set; }

		[FieldOffset(40, 144)]
		public float SnapCenterYOffset { get; set; }

		[FieldOffset(44, 148)]
		public float ShrinkSnapAnimationTime { get; set; }

		[FieldOffset(48, 152)]
		public float TrackerHudRadiusX { get; set; }

		[FieldOffset(52, 156)]
		public float TrackerHudRadiusY { get; set; }

		[FieldOffset(56, 160)]
		public float MaxLookAtThreshold { get; set; }

		[FieldOffset(60, 164)]
		public float MinLookAtThreshold { get; set; }

		[FieldOffset(64, 168)]
		public float MinLookAtThresholdDistance { get; set; }

		[FieldOffset(68, 172)]
		public float DrawDistance { get; set; }

		[FieldOffset(72, 176)]
		public float FadeDistance { get; set; }

		[FieldOffset(76, 180)]
		public float FadeEndDistance { get; set; }

		[FieldOffset(80, 184)]
		public float MinimumDrawDistance { get; set; }

		[FieldOffset(84, 188)]
		public float MinimumFadeDistance { get; set; }

		[FieldOffset(88, 192)]
		public float MaxFarFade { get; set; }

		[FieldOffset(92, 196)]
		public float MaxCloseFade { get; set; }

		[FieldOffset(96, 200)]
		public float ShowLabelRange { get; set; }

		[FieldOffset(100, 204)]
		public float TeamRadioDistance { get; set; }

		[FieldOffset(104, 208)]
		public float ScaleDistance { get; set; }

		[FieldOffset(108, 212)]
		public float MaxScaleMod { get; set; }

		[FieldOffset(112, 216)]
		public float MaxXRotation { get; set; }

		[FieldOffset(116, 220)]
		public float MaxYRotation { get; set; }

		[FieldOffset(120, 224)]
		public float HorisontalOffset { get; set; }

		[FieldOffset(124, 228)]
		public float VerticalOffset { get; set; }

		[FieldOffset(128, 232)]
		public Vec2 PixelOffset { get; set; }

		[FieldOffset(136, 240)]
		public float VerticalOffsetScaleFactor { get; set; }

		[FieldOffset(140, 244)]
		public float VerticalOffsetMaxOffset { get; set; }

		[FieldOffset(144, 248)]
		public float ShowMedicHealthThreshold { get; set; }

		[FieldOffset(148, 252)]
		public float ShowEngineerArmorThreshold { get; set; }

		[FieldOffset(152, 256)]
		public float ShowSupportAmmoThreshold { get; set; }

		[FieldOffset(156, 260)]
		public int MaxTagUpdatesPerFrame { get; set; }

		[FieldOffset(160, 264)]
		public bool SnapIcons { get; set; }

		[FieldOffset(161, 265)]
		public bool CircularSnap { get; set; }

		[FieldOffset(162, 266)]
		public bool OnlyShowSnapped { get; set; }
	}
}
