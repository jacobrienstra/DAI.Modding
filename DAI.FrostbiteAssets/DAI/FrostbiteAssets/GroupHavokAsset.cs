using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class GroupHavokAsset : HavokAsset
	{
		[FieldOffset(32, 112)]
		public List<AssetAabbs> Aabb { get; set; }

		public GroupHavokAsset()
		{
			Aabb = new List<AssetAabbs>();
		}
	}
}
