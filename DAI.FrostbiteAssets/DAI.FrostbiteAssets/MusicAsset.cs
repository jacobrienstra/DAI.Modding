using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicAsset : MusicBaseAsset
	{
		[FieldOffset(24, 88)]
		public uint NameHash { get; set; }

		[FieldOffset(28, 92)]
		public uint BeatsPerMinute { get; set; }

		[FieldOffset(32, 96)]
		public uint BeatsPerBar { get; set; }

		[FieldOffset(36, 104)]
		public List<ExternalObject<MusicPhraseData>> Playables { get; set; }

		[FieldOffset(40, 112)]
		public List<ExternalObject<Dummy>> Overlays { get; set; }

		[FieldOffset(44, 120)]
		public List<ExternalObject<MusicPhraseData>> Selectors { get; set; }

		[FieldOffset(48, 128)]
		public ExternalObject<MusicSelector> DefaultSelector { get; set; }

		[FieldOffset(52, 136)]
		public List<ExternalObject<MusicPhraseData>> FallbackTransitions { get; set; }

		[FieldOffset(56, 144)]
		public byte VoicePriority { get; set; }

		[FieldOffset(57, 145)]
		public bool MustSurviveLevelLoads { get; set; }

		public MusicAsset()
		{
			Playables = new List<ExternalObject<MusicPhraseData>>();
			Overlays = new List<ExternalObject<Dummy>>();
			Selectors = new List<ExternalObject<MusicPhraseData>>();
			FallbackTransitions = new List<ExternalObject<MusicPhraseData>>();
		}
	}
}
