namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CameraDirectorKeyframe : DataContainer
	{
		[FieldOffset(8, 24)]
		public float Time { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<CameraTrackData> CameraTrack { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<CameraDirectorTrackBaseData> ParentDirectorTrack { get; set; }
	}
}
