namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DefensiveCollisionDefinition
	{
		[FieldOffset(0, 0)]
		public Vec3 BoneOffset { get; set; }

		[FieldOffset(16, 16)]
		public int BoneId { get; set; }

		[FieldOffset(20, 20)]
		public float Radius { get; set; }

		[FieldOffset(24, 24)]
		public int TargetIndex { get; set; }

		[FieldOffset(28, 28)]
		public uint DisableLayer { get; set; }

		[FieldOffset(32, 32)]
		public float MaxAttachmentDepth { get; set; }

		[FieldOffset(36, 36)]
		public bool CollidesWithProjectiles { get; set; }
	}
}
