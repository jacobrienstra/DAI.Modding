using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EventSequencerNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Start { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Stop { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Interval { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort IntervalVariation { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort Repeat { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort RepeatVariation { get; set; }

		[FieldOffset(56, 240)]
		public List<ExternalObject<ConeOutputNodeData>> OutEvents { get; set; }

		[FieldOffset(60, 248)]
		public EventSequencerPlayback Playback { get; set; }

		[FieldOffset(64, 252)]
		public bool IgnoreFirstInterval { get; set; }

		public EventSequencerNodeData()
		{
			OutEvents = new List<ExternalObject<ConeOutputNodeData>>();
		}
	}
}
