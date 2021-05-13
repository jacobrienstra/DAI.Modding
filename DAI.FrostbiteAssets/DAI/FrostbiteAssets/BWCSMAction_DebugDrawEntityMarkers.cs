namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_DebugDrawEntityMarkers : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<EntityListProvider_ConditionalFilter> EntityList { get; set; }

		[FieldOffset(32, 80)]
		public Vec3 MarkerColor { get; set; }

		[FieldOffset(48, 96)]
		public ExternalObject<TransformProvider_Translate> Transform { get; set; }

		[FieldOffset(52, 104)]
		public string Label { get; set; }

		[FieldOffset(56, 112)]
		public ExternalObject<FloatProvider_Const> Radius { get; set; }

		[FieldOffset(60, 120)]
		public ExternalObject<Dummy> Height { get; set; }

		[FieldOffset(64, 128)]
		public byte MarkerAlpha { get; set; }

		[FieldOffset(65, 129)]
		public bool UseDepthTest { get; set; }
	}
}
