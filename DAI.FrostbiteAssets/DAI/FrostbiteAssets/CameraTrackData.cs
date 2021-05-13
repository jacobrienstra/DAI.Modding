namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CameraTrackData : CameraTrackBaseData
	{
		[FieldOffset(24, 128)]
		public ExternalObject<LayeredTransformTrackData> LayeredTransformTrack { get; set; }

		[FieldOffset(28, 136)]
		public ExternalObject<FloatTrackData> FovTrack { get; set; }
	}
}
