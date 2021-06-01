using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClothSectionMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ClothMeshName { get; set; }

		[FieldOffset(4, 8)]
		public List<uint> SubsetIds { get; set; }

		[FieldOffset(8, 16)]
		public uint LodIndex { get; set; }

		public ClothSectionMapping()
		{
			SubsetIds = new List<uint>();
		}
	}
}
