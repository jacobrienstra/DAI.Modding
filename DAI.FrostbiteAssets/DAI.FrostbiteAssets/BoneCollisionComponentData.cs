namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BoneCollisionComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<SkeletonCollisionData> SkeletonCollisionData { get; set; }
	}
}
