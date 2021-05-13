using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPMatchSettingsData : SystemSettings
	{
		[FieldOffset(16, 40)]
		public List<ExternalObject<SystemSettings>> MatchVisibilityModes { get; set; }

		[FieldOffset(20, 48)]
		public List<ExternalObject<SystemSettings>> MatchDifficultyModes { get; set; }

		[FieldOffset(24, 56)]
		public UITextureAtlasTextureReference RandomQuickmatchDifficultyIcon { get; set; }

		public MPMatchSettingsData()
		{
			MatchVisibilityModes = new List<ExternalObject<SystemSettings>>();
			MatchDifficultyModes = new List<ExternalObject<SystemSettings>>();
		}
	}
}
