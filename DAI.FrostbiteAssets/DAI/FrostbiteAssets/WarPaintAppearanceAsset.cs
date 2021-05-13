namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class WarPaintAppearanceAsset : Asset
	{
		[FieldOffset(12, 72)]
		public string WarPaintColor4ParameterName { get; set; }

		[FieldOffset(16, 80)]
		public Vec4 WarPaintColor4 { get; set; }

		[FieldOffset(32, 96)]
		public Vec4 WarPaintColor3 { get; set; }

		[FieldOffset(48, 112)]
		public Vec4 WarPaintColor2 { get; set; }

		[FieldOffset(64, 128)]
		public Vec4 WarPaintColor1 { get; set; }

		[FieldOffset(80, 144)]
		public Vec4 WarPaintChannelSelector { get; set; }

		[FieldOffset(96, 160)]
		public string WarPaintColor3ParameterName { get; set; }

		[FieldOffset(100, 168)]
		public string WarPaintColor2ParameterName { get; set; }

		[FieldOffset(104, 176)]
		public string WarPaintColor1ParameterName { get; set; }

		[FieldOffset(108, 184)]
		public string WarPaintChannelSelectorParameterName { get; set; }

		[FieldOffset(112, 192)]
		public string WarPaintMaskParameterName { get; set; }

		[FieldOffset(116, 200)]
		public ExternalObject<TextureAsset> IronBullWarPaintMask { get; set; }

		[FieldOffset(120, 208)]
		public ExternalObject<TextureAsset> QunariInquisitorWarPaintMask { get; set; }
	}
}
