using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicSelector : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<MusicEventData> Event { get; set; }

		[FieldOffset(12, 32)]
		public MusicSelectorTriggerType TriggerType { get; set; }

		[FieldOffset(16, 36)]
		public MusicSyncType SyncType { get; set; }

		[FieldOffset(20, 40)]
		public ExternalObject<MusicPhraseData> Target { get; set; }

		[FieldOffset(24, 48)]
		public ExternalObject<MusicTransition> Default { get; set; }

		[FieldOffset(28, 56)]
		public List<ExternalObject<MusicPhraseData>> Transitions { get; set; }

		public MusicSelector()
		{
			Transitions = new List<ExternalObject<MusicPhraseData>>();
		}
	}
}
