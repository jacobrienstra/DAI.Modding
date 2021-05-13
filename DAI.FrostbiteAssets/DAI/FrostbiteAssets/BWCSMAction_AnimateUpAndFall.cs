namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_AnimateUpAndFall : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public int StoredTransformSlot { get; set; }

		[FieldOffset(32, 80)]
		public Vec3 DropPointTranslation { get; set; }

		[FieldOffset(48, 96)]
		public Vec3 DropPointVelocity { get; set; }

		[FieldOffset(64, 112)]
		public Vec3 FallingHorizontalDistanceTravelled { get; set; }

		[FieldOffset(80, 128)]
		public float DropPointTime { get; set; }
	}
}
