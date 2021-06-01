namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinematicHeightAdjustmentControllerData : CinebotControllerData
	{
		[FieldOffset(24, 112)]
		public string LookFromTrackableName { get; set; }

		[FieldOffset(28, 120)]
		public string LookAtTrackableName { get; set; }

		[FieldOffset(32, 128)]
		public float FOV { get; set; }
	}
}
