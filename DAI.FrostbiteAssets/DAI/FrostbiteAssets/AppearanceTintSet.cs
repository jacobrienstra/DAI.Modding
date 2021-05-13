namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AppearanceTintSet : Asset
	{
		[FieldOffset(12, 72)]
		public bool UseOverrideMetalTints { get; set; }

		[FieldOffset(16, 80)]
		public Vec4 TintColor1 { get; set; }

		[FieldOffset(32, 96)]
		public Vec4 TintColor2 { get; set; }

		[FieldOffset(48, 112)]
		public Vec4 TintColor3 { get; set; }

		[FieldOffset(64, 128)]
		public Vec4 TintColor4 { get; set; }

		[FieldOffset(80, 144)]
		public Vec4 TintWeights { get; set; }

		[FieldOffset(96, 160)]
		public Vec4 OverrideMetal { get; set; }

		[FieldOffset(112, 176)]
		public Vec4 OverrideMetalColor { get; set; }

		[FieldOffset(128, 192)]
		public Vec4 MetalSmoothnessOverride { get; set; }
	}
}
