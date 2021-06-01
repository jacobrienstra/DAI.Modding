using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JournalSystemEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public JournalSystemGameMode GameMode { get; set; }

		[FieldOffset(20, 104)]
		public List<ExternalObject<LogicPrefabReferenceObjectData>> JournalSystems { get; set; }

		[FieldOffset(24, 112)]
		public int UpdatedJournalTimeoutInMilliSeconds { get; set; }

		[FieldOffset(28, 120)]
		public LocalizedStringReference CodexUpdateMessage { get; set; }

		[FieldOffset(32, 144)]
		public LocalizedStringReference CodexUnlockedMessage { get; set; }

		[FieldOffset(36, 168)]
		public LocalizedStringReference QuestUpdateMessage { get; set; }

		[FieldOffset(40, 192)]
		public LocalizedStringReference NewQuestMessage { get; set; }

		[FieldOffset(44, 216)]
		public LocalizedStringReference CompletedQuestMessage { get; set; }

		[FieldOffset(48, 240)]
		public LocalizedStringReference QuestTaskPresentationMessage { get; set; }

		[FieldOffset(52, 264)]
		public LocalizedStringReference NewWarTableMessage { get; set; }

		[FieldOffset(56, 288)]
		public LocalizedStringReference NewWarTableMultipleMessage { get; set; }

		[FieldOffset(60, 312)]
		public short NetworkBufferSizeInBytes { get; set; }

		public JournalSystemEntityData()
		{
			JournalSystems = new List<ExternalObject<LogicPrefabReferenceObjectData>>();
		}
	}
}
