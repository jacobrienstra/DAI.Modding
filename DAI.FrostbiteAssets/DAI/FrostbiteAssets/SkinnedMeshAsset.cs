namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SkinnedMeshAsset : MeshAsset
	{
		[FieldOffset(80, 384)]
		public Vec3 BoundingBoxPositionOffset { get; set; }

		[FieldOffset(96, 400)]
		public Vec3 BoundingBoxSizeOffset { get; set; }
	}
}
