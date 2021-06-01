using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class ClothAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ClothSectionMapping> MeshSectionMappings { get; set; }

		[FieldOffset(16, 80)]
		public long HavokClothResource { get; set; }

		[FieldOffset(24, 88)]
		public ClothStatesSetup StatesSetup { get; set; }

		[FieldOffset(44, 128)]
		public List<uint> DisplayBufferIndices { get; set; }

		[FieldOffset(48, 136)]
		public List<uint> BoneIndexLookup { get; set; }

		[FieldOffset(52, 144)]
		public List<uint> SimulatedAndParentBonesLookup { get; set; }

		[FieldOffset(56, 152)]
		public List<bool> UsedBySimulation { get; set; }

		public ClothAsset()
		{
			MeshSectionMappings = new List<ClothSectionMapping>();
			DisplayBufferIndices = new List<uint>();
			BoneIndexLookup = new List<uint>();
			SimulatedAndParentBonesLookup = new List<uint>();
			UsedBySimulation = new List<bool>();
		}
	}
}
