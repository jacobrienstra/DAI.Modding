namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScaleTransformLayerData : TransformLayerData
	{
		[FieldOffset(32, 144)]
		public ExternalObject<FloatTrackData> ScaleX { get; set; }

		[FieldOffset(36, 152)]
		public ExternalObject<FloatTrackData> ScaleY { get; set; }

		[FieldOffset(40, 160)]
		public ExternalObject<FloatTrackData> ScaleZ { get; set; }

		[FieldOffset(44, 168)]
		public bool IsUniform { get; set; }
	}
}
