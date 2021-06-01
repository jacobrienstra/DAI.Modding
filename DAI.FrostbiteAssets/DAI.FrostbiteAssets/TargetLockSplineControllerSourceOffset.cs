namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TargetLockSplineControllerSourceOffset
	{
		[FieldOffset(0, 0)]
		public Vec3 MinimumSourceOffset { get; set; }

		[FieldOffset(16, 16)]
		public Vec3 MaximumSourceOffset { get; set; }

		[FieldOffset(32, 32)]
		public float MimimumDistanceTotarget { get; set; }

		[FieldOffset(36, 36)]
		public float MaximumDistanceTotarget { get; set; }
	}
}
