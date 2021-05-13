using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingSizeConfiguration : LinkObject
	{
		[FieldOffset(0, 0)]
		public MatchmakingPlatform Platform { get; set; }

		[FieldOffset(4, 8)]
		public List<string> Settings { get; set; }

		[FieldOffset(8, 16)]
		public uint DesiredPlayerCount { get; set; }

		[FieldOffset(12, 20)]
		public uint MinPlayerCount { get; set; }

		[FieldOffset(16, 24)]
		public uint MaxPlayerCount { get; set; }

		[FieldOffset(20, 32)]
		public string RangeOffsetListName { get; set; }

		[FieldOffset(24, 40)]
		public string PlayerSlotsRangeOffsetListName { get; set; }

		public MatchmakingSizeConfiguration()
		{
			Settings = new List<string>();
		}
	}
}
