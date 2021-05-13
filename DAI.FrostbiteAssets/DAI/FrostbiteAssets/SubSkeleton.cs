using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SubSkeleton : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Dummy> Skeleton { get; set; }

		[FieldOffset(4, 8)]
		public List<Dummy> BoneMap { get; set; }

		[FieldOffset(8, 16)]
		public List<LinearTransform> TransformMap { get; set; }

		public SubSkeleton()
		{
			BoneMap = new List<Dummy>();
			TransformMap = new List<LinearTransform>();
		}
	}
}
