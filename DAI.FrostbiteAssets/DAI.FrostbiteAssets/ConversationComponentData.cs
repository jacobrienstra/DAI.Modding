using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ConversationComponentData : ComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<ConversationTypesGlobalAsset> ConversationTypes { get; set; }

		[FieldOffset(100, 184)]
		public List<uint> ConversationBoneHashes { get; set; }

		[FieldOffset(104, 192)]
		public List<Vec3> ConversationBoneLocalPositions { get; set; }

		public ConversationComponentData()
		{
			ConversationBoneHashes = new List<uint>();
			ConversationBoneLocalPositions = new List<Vec3>();
		}
	}
}
