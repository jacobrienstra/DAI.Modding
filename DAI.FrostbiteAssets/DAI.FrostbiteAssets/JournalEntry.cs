using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JournalEntry : JournalEntryBase
	{
		[FieldOffset(32, 136)]
		public List<uint> TaskEntryHashes { get; set; }

		[FieldOffset(36, 144)]
		public JournalQuestType QuestType { get; set; }

		[FieldOffset(40, 152)]
		public List<PlotConditionReference> FailureConditions { get; set; }

		[FieldOffset(44, 160)]
		public uint FailureTextEntryHash { get; set; }

		[FieldOffset(48, 164)]
		public int SortingPriority { get; set; }

		public JournalEntry()
		{
			TaskEntryHashes = new List<uint>();
			FailureConditions = new List<PlotConditionReference>();
		}
	}
}
