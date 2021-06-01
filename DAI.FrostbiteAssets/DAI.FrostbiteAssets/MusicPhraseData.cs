using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicPhraseData : MusicStreamableData
	{
		[FieldOffset(64, 96)]
		public MusicPhraseSelectionType SelectionType { get; set; }

		[FieldOffset(68, 104)]
		public ExternalObject<MusicParameterData> SelectionParameter { get; set; }

		[FieldOffset(72, 112)]
		public ExternalObject<SynchedFadeData> RangeFade { get; set; }

		[FieldOffset(76, 120)]
		public List<ExternalObject<MusicPhraseData>> Playables { get; set; }

		[FieldOffset(80, 128)]
		public bool RestartIfAlreadyPlaying { get; set; }

		public MusicPhraseData()
		{
			Playables = new List<ExternalObject<MusicPhraseData>>();
		}
	}
}
