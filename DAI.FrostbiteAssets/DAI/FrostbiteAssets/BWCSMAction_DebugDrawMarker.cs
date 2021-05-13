namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_DebugDrawMarker : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<TransformProvider> Transform { get; set; }

		[FieldOffset(32, 80)]
		public Vec3 MarkerColor { get; set; }

		[FieldOffset(48, 96)]
		public Vec3 Marker2Color { get; set; }

		[FieldOffset(64, 112)]
		public ExternalObject<TransformProvider> Transform2 { get; set; }

		[FieldOffset(68, 120)]
		public string Label { get; set; }

		[FieldOffset(72, 128)]
		public string Label2 { get; set; }

		[FieldOffset(76, 136)]
		public ExternalObject<FloatProvider_Const> Radius { get; set; }

		[FieldOffset(80, 144)]
		public ExternalObject<FloatProvider_Const> Height { get; set; }

		[FieldOffset(84, 152)]
		public byte MarkerAlpha { get; set; }

		[FieldOffset(85, 153)]
		public bool UseDepthTest { get; set; }

		[FieldOffset(86, 154)]
		public bool Connect { get; set; }

		[FieldOffset(87, 155)]
		public bool CoordinateAxes { get; set; }
	}
}
