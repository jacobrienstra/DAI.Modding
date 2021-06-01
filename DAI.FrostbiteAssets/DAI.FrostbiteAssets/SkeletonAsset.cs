using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SkeletonAsset : BaseSkeletonAsset
	{
		[FieldOffset(12, 72)]
		public List<string> BoneNames { get; set; }

		[FieldOffset(16, 80)]
		public List<uint> BoneNameHashes { get; set; }

		[FieldOffset(20, 88)]
		public List<int> Hierarchy { get; set; }

		[FieldOffset(24, 96)]
		public List<LinearTransform> LocalPose { get; set; }

		[FieldOffset(28, 104)]
		public List<LinearTransform> ModelPose { get; set; }

		[FieldOffset(32, 112)]
		public List<int> ServerSkeletonToSkeletonMap { get; set; }

		[FieldOffset(36, 120)]
		public List<int> SkeletonToServerSkeletonMap { get; set; }

		[FieldOffset(40, 128)]
		public List<int> ServerHierarchy { get; set; }

		[FieldOffset(44, 136)]
		public List<int> GameplayBonesToSkeleton { get; set; }

		[FieldOffset(48, 144)]
		public List<int> GameplayBonesToServerSkeleton { get; set; }

		public SkeletonAsset()
		{
			BoneNames = new List<string>();
			BoneNameHashes = new List<uint>();
			Hierarchy = new List<int>();
			LocalPose = new List<LinearTransform>();
			ModelPose = new List<LinearTransform>();
			ServerSkeletonToSkeletonMap = new List<int>();
			SkeletonToServerSkeletonMap = new List<int>();
			ServerHierarchy = new List<int>();
			GameplayBonesToSkeleton = new List<int>();
			GameplayBonesToServerSkeleton = new List<int>();
		}
	}
}
