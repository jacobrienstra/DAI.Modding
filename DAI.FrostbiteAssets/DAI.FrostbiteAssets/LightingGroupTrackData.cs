namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LightingGroupTrackData : GroupTrackData
	{
		[FieldOffset(28, 136)]
		public ExternalObject<CameraTrackData> CameraTrack { get; set; }
	}
}
