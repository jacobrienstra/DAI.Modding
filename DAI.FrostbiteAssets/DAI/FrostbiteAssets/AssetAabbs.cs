using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AssetAabbs : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<AxisAlignedBox> PartAabb { get; set; }

		public AssetAabbs()
		{
			PartAabb = new List<AxisAlignedBox>();
		}
	}
}
