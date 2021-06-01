using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationLine : ConversationTreeNode
	{
		[FieldOffset(36, 136)]
		public SubtitleBehavior ForceSubtitles { get; set; }

		[FieldOffset(40, 144)]
		public ConversationStringReference TextReference { get; set; }

		[FieldOffset(52, 184)]
		public ConversationLineOccurrence Occurrence { get; set; }

		[FieldOffset(56, 188)]
		public PlotFlagId OccurrencePlotFlagId { get; set; }

		[FieldOffset(72, 208)]
		public List<PlotActionReference> PlotActions { get; set; }

		[FieldOffset(76, 216)]
		public List<PlotConditionReference> PlotConditions { get; set; }

		[FieldOffset(80, 224)]
		public string SchematicOutput { get; set; }

		[FieldOffset(84, 232)]
		public string SchematicStartEvent { get; set; }

		[FieldOffset(88, 240)]
		public HasTimelineSetting HasTimelineUserOverride { get; set; }

		[FieldOffset(92, 244)]
		public float CutOffTime { get; set; }

		[FieldOffset(96, 248)]
		public TimeRestrictionType TimeRestriction { get; set; }

		[FieldOffset(100, 252)]
		public int TimelineLinkID { get; set; }

		[FieldOffset(104, 256)]
		public CharacterGender SpeakerGender { get; set; }

		[FieldOffset(108, 264)]
		public ExternalObject<ConversationLine> BranchInLine { get; set; }

		[FieldOffset(112, 272)]
		public ExternalObject<ConversationLine> BranchOutLine { get; set; }

		[FieldOffset(116, 280)]
		public ConversationSelectionMethod SelectionMethod { get; set; }

		[FieldOffset(120, 288)]
		public ExternalObject<SoundPatchAsset> VOPlayback { get; set; }

		[FieldOffset(124, 296)]
		public bool Unskippable { get; set; }

		[FieldOffset(125, 297)]
		public bool SkipWholeTimelineAtOnce { get; set; }

		[FieldOffset(126, 298)]
		public bool TakesControl { get; set; }

		public ConversationLine()
		{
			PlotActions = new List<PlotActionReference>();
			PlotConditions = new List<PlotConditionReference>();
		}
	}
}
