namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_FaceTarget : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public float RotationOffset { get; set; }

		[FieldOffset(32, 76)]
		public float MinAngleThreshold { get; set; }

		[FieldOffset(36, 80)]
		public bool UseAOETarget { get; set; }

		[FieldOffset(37, 81)]
		public bool UseAOETargetingOrientation { get; set; }
	}
}
