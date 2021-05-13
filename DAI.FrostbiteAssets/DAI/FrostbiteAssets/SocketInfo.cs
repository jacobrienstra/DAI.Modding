namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SocketInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public LinearTransform TransformOffset { get; set; }

		[FieldOffset(64, 64)]
		public string BoneName { get; set; }

		[FieldOffset(68, 72)]
		public int BoneNameHash { get; set; }

		[FieldOffset(72, 80)]
		public string MirroredBoneName { get; set; }

		[FieldOffset(76, 88)]
		public int MirroredBoneNameHash { get; set; }

		[FieldOffset(80, 96)]
		public SocketBoneId BoneId { get; set; }
	}
}
