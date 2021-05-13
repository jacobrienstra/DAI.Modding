using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SkeletonCollisionData : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<SkeletonAsset> SkeletonAsset { get; set; }

		[FieldOffset(12, 32)]
		public List<BoneCollisionData> BoneCollisionData { get; set; }

		public SkeletonCollisionData()
		{
			BoneCollisionData = new List<BoneCollisionData>();
		}
	}
}
