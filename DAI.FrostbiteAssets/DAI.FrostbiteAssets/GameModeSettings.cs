using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameModeSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public List<GameModeInformation> Information { get; set; }

		public GameModeSettings()
		{
			Information = new List<GameModeInformation>();
		}
	}
}
