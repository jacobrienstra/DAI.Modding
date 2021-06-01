namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinematicCameraTrackData : CameraTrackData
	{
		[FieldOffset(32, 144)]
		public ExternalObject<DofTrackData> DofTrack { get; set; }
	}
}
