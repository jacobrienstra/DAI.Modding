namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class StandardSocketInfo : AppearanceSocketInfo
	{
		[FieldOffset(8, 24)]
		public int BoneId { get; set; }

		[FieldOffset(16, 32)]
		public LinearTransform OffsetTransform { get; set; }

		[FieldOffset(80, 96)]
		public Vec3 TranslationOffset { get; set; }

		[FieldOffset(96, 112)]
		public Vec3 RotationOffset { get; set; }
	}
}
