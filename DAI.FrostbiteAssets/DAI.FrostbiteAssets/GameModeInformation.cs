using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameModeInformation : LinkObject
	{
		[FieldOffset(0, 0)]
		public GamePlatform Platform { get; set; }

		[FieldOffset(4, 8)]
		public List<GameModeSize> Sizes { get; set; }

		[FieldOffset(8, 16)]
		public GameModeSize DefaultSize { get; set; }

		[FieldOffset(36, 64)]
		public bool AllowFallbackToDefault { get; set; }

		public GameModeInformation()
		{
			Sizes = new List<GameModeSize>();
		}
	}
}
