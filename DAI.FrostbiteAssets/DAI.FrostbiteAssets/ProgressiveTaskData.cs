using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProgressiveTaskData : LinkObject
	{
		[FieldOffset(0, 0)]
		public JournalContentType ContentType { get; set; }

		[FieldOffset(4, 4)]
		public uint Hash { get; set; }

		[FieldOffset(8, 8)]
		public List<PlotConditionReference> DisplayConditions { get; set; }

		[FieldOffset(12, 16)]
		public List<PlotConditionReference> HideConditions { get; set; }

		[FieldOffset(16, 24)]
		public LocalizedStringReference TextReference { get; set; }

		[FieldOffset(20, 48)]
		public List<PlotConditionReference> SuccessConditions { get; set; }

		[FieldOffset(24, 56)]
		public List<ExternalObject<CodexEntry>> CompletionRewards { get; set; }

		[FieldOffset(28, 64)]
		public List<PlotConditionReference> FailureConditions { get; set; }

		[FieldOffset(32, 72)]
		public string TexturePath { get; set; }

		[FieldOffset(36, 80)]
		public PlotFlagReference CurrentProgress { get; set; }

		[FieldOffset(52, 120)]
		public PlotFlagReference Total { get; set; }

		[FieldOffset(68, 160)]
		public QuestTrackerDisplayType QuestTrackerDisplayType { get; set; }

		public ProgressiveTaskData()
		{
			DisplayConditions = new List<PlotConditionReference>();
			HideConditions = new List<PlotConditionReference>();
			SuccessConditions = new List<PlotConditionReference>();
			CompletionRewards = new List<ExternalObject<CodexEntry>>();
			FailureConditions = new List<PlotConditionReference>();
		}
	}
}
