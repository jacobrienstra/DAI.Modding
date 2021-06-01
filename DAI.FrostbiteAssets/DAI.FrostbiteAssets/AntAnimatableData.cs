namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntAnimatableData : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef Actor { get; set; }

		[FieldOffset(20, 48)]
		public AntRef SceneOpMatrix { get; set; }

		[FieldOffset(40, 96)]
		public AntRef CollisionWorld { get; set; }

		[FieldOffset(60, 144)]
		public AntRef RightHandEffectorDisableOverride { get; set; }

		[FieldOffset(80, 192)]
		public AntRef LeftHandEffectorDisableOverride { get; set; }

		[FieldOffset(100, 240)]
		public ExternalObject<MasterSkeletonAsset> MasterSkeletonAsset { get; set; }
	}
}
