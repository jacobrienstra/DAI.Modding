namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(1)]
	public class PoseConstraintsData
	{
		[FieldOffset(0, 0)]
		public bool StandPose { get; set; }

		[FieldOffset(1, 1)]
		public bool CrouchPose { get; set; }

		[FieldOffset(2, 2)]
		public bool PronePose { get; set; }
	}
}
