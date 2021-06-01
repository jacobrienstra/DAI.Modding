namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PhantomComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public Vec3 BoxSize { get; set; }

		[FieldOffset(112, 192)]
		public int AttachmentPoint { get; set; }

		[FieldOffset(116, 200)]
		public AntRef AsyncQueryPointerAsset { get; set; }

		[FieldOffset(136, 248)]
		public AntRef EnableTrajectoryOverride { get; set; }

		[FieldOffset(156, 296)]
		public AntRef TrajectoryOverride { get; set; }
	}
}
