using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Conversation : TreeBase
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<ConversationLine>> ChildNodes { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<ConversationTypeSettings> TypeSettings { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<LocalizedCharacter> PrimarySpeaker { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<StageEntityData> Stage { get; set; }

		[FieldOffset(28, 104)]
		public ExternalObject<SoundPatchAsset> VOPlayback { get; set; }

		[FieldOffset(32, 112)]
		public bool LargeConversation { get; set; }

		public Conversation()
		{
			ChildNodes = new List<ExternalObject<ConversationLine>>();
		}
	}
}
