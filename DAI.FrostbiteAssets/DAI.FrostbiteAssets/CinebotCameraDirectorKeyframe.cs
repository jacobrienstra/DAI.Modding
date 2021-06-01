namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotCameraDirectorKeyframe : CameraDirectorKeyframe
	{
		[FieldOffset(20, 48)]
		public ExternalObject<Dummy> Transition { get; set; }

		[FieldOffset(24, 56)]
		public bool RecalculateCinebot { get; set; }
	}
}
