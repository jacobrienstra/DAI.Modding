namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICppScreenData : Asset
	{
		[FieldOffset(12, 72)]
		public float FieldOfView { get; set; }

		[FieldOffset(16, 76)]
		public float ScreenLayoutWidth { get; set; }

		[FieldOffset(20, 80)]
		public float ScreenLayoutHeight { get; set; }

		[FieldOffset(24, 84)]
		public bool ScaleUpAndKeepAspectRatio { get; set; }

		[FieldOffset(25, 85)]
		public bool FlashCompatibilityMode { get; set; }

		[FieldOffset(26, 86)]
		public bool EatAllInput { get; set; }

		[FieldOffset(27, 87)]
		public bool AllowInput { get; set; }

		[FieldOffset(28, 88)]
		public bool LayoutWithSafeZone { get; set; }
	}
}
