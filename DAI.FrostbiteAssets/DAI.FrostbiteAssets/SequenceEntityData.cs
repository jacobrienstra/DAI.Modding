using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SequenceEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<SequenceEventData> Events { get; set; }

		[FieldOffset(20, 104)]
		public int SequenceStartTime { get; set; }

		[FieldOffset(24, 108)]
		public int SequenceLength { get; set; }

		[FieldOffset(28, 112)]
		public Realm Realm { get; set; }

		[FieldOffset(32, 120)]
		public List<ExternalObject<DataContainer>> PropertyTracks { get; set; }

		[FieldOffset(36, 128)]
		public List<ExternalObject<Dummy>> CustomSequenceTracks { get; set; }

		[FieldOffset(40, 136)]
		public UpdatePass ClientUpdatePass { get; set; }

		[FieldOffset(44, 140)]
		public UpdatePass ServerUpdatePass { get; set; }

		[FieldOffset(48, 144)]
		public float ExternalTime { get; set; }

		[FieldOffset(52, 148)]
		public float PlaybackSpeed { get; set; }

		[FieldOffset(56, 152)]
		public bool Looping { get; set; }

		[FieldOffset(57, 153)]
		public bool AutoStart { get; set; }

		[FieldOffset(58, 154)]
		public bool AutoPlayFirstFrame { get; set; }

		[FieldOffset(59, 155)]
		public bool PlayInReverse { get; set; }

		public SequenceEntityData()
		{
			Events = new List<SequenceEventData>();
			PropertyTracks = new List<ExternalObject<DataContainer>>();
			CustomSequenceTracks = new List<ExternalObject<Dummy>>();
		}
	}
}
