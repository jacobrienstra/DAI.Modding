using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameModeSize : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public string ShortName { get; set; }

		[FieldOffset(8, 16)]
		public string MetaIdentifier { get; set; }

		[FieldOffset(12, 24)]
		public uint PlayerCount { get; set; }

		[FieldOffset(16, 32)]
		public List<GameModeTeamSize> Teams { get; set; }

		[FieldOffset(20, 40)]
		public uint RoundsPerMap { get; set; }

		[FieldOffset(24, 44)]
		public bool ForceSquad { get; set; }

		public GameModeSize()
		{
			Teams = new List<GameModeTeamSize>();
		}
	}
}
