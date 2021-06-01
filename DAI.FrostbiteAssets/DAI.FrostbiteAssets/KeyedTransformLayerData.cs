namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class KeyedTransformLayerData : TransformLayerData
	{
		[FieldOffset(32, 144)]
		public ExternalObject<FloatTrackData> TranslationX { get; set; }

		[FieldOffset(36, 152)]
		public ExternalObject<FloatTrackData> TranslationY { get; set; }

		[FieldOffset(40, 160)]
		public ExternalObject<FloatTrackData> TranslationZ { get; set; }

		[FieldOffset(44, 168)]
		public ExternalObject<FloatTrackData> RotationX { get; set; }

		[FieldOffset(48, 176)]
		public ExternalObject<FloatTrackData> RotationY { get; set; }

		[FieldOffset(52, 184)]
		public ExternalObject<FloatTrackData> RotationZ { get; set; }

		[FieldOffset(56, 192)]
		public bool ForceMinimumRotationPathBetweenKeys { get; set; }
	}
}
