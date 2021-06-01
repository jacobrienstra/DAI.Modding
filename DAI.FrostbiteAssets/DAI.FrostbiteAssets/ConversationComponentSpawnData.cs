using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationComponentSpawnData : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<uint> ConversationBoneHashes { get; set; }

		[FieldOffset(12, 32)]
		public List<Vec3> ConversationBoneLocalPositions { get; set; }

		public ConversationComponentSpawnData()
		{
			ConversationBoneHashes = new List<uint>();
			ConversationBoneLocalPositions = new List<Vec3>();
		}
	}
}
