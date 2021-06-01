using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundWaveAsset : SoundDataAsset
	{
		[FieldOffset(24, 104)]
		public List<SoundWaveRuntimeVariation> RuntimeVariations { get; set; }

		[FieldOffset(28, 112)]
		public List<SoundWaveLocalizationInfo> Localization { get; set; }

		[FieldOffset(32, 120)]
		public List<string> SubtitleStringIds { get; set; }

		[FieldOffset(36, 128)]
		public List<SoundWaveSubtitle> Subtitles { get; set; }

		[FieldOffset(40, 136)]
		public SoundWaveVariationSelection Selection { get; set; }

		[FieldOffset(44, 144)]
		public ExternalObject<StreamPoolAsset> StreamPool { get; set; }

		[FieldOffset(48, 152)]
		public List<SoundWaveVariationSegment> Segments { get; set; }

		[FieldOffset(52, 160)]
		public bool Seekable { get; set; }

		[FieldOffset(53, 161)]
		public byte VariationHistoryCount { get; set; }

		[FieldOffset(54, 162)]
		public byte PersistentVariationCount { get; set; }

		[FieldOffset(55, 163)]
		public bool PreferAvailableVariations { get; set; }

		[FieldOffset(56, 164)]
		public byte StreamingMode { get; set; }

		[FieldOffset(57, 165)]
		public byte ChannelCount { get; set; }

		[FieldOffset(58, 166)]
		public byte VoicePriority { get; set; }

		public SoundWaveAsset()
		{
			RuntimeVariations = new List<SoundWaveRuntimeVariation>();
			Localization = new List<SoundWaveLocalizationInfo>();
			SubtitleStringIds = new List<string>();
			Subtitles = new List<SoundWaveSubtitle>();
			Segments = new List<SoundWaveVariationSegment>();
		}
	}
}
