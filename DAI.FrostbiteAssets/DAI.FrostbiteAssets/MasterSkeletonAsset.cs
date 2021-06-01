using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MasterSkeletonAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<SkeletonAsset> MasterSkeleton { get; set; }

		[FieldOffset(16, 80)]
		public List<SubSkeleton> SubSkeletons { get; set; }

		public MasterSkeletonAsset()
		{
			SubSkeletons = new List<SubSkeleton>();
		}
	}
}
