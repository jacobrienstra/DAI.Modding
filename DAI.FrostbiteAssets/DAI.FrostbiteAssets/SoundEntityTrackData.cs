using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundEntityTrackData : GuideTrackData
	{
		[FieldOffset(28, 136)]
		public ExternalObject<SoundPatchConfigurationAsset> Sound { get; set; }

		[FieldOffset(32, 144)]
		public uint BufferEventHash { get; set; }

		[FieldOffset(36, 148)]
		public uint SeekToEventHash { get; set; }

		[FieldOffset(40, 152)]
		public uint SeekToParameterHash { get; set; }

		[FieldOffset(44, 160)]
		public List<ExternalObject<EntityData>> LayerTracks { get; set; }

		[FieldOffset(48, 168)]
		public bool FireDefaultStopEventOnComplete { get; set; }

		[FieldOffset(49, 169)]
		public bool UseSoundTimeForGuide { get; set; }

		[FieldOffset(50, 170)]
		public bool ForceStopWithTimeline { get; set; }

		public SoundEntityTrackData()
		{
			LayerTracks = new List<ExternalObject<EntityData>>();
		}
	}
}
