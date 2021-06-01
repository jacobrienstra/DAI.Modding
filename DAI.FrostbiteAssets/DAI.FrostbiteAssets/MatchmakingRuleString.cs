using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingRuleString : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Value { get; set; }

		[FieldOffset(4, 8)]
		public MatchmakingPlatform Platform { get; set; }

		[FieldOffset(8, 16)]
		public List<Dummy> Licenses { get; set; }

		[FieldOffset(12, 24)]
		public bool UseOnlyIfEmpty { get; set; }

		public MatchmakingRuleString()
		{
			Licenses = new List<Dummy>();
		}
	}
}
