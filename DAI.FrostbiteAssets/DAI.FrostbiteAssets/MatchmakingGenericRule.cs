using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingGenericRule : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Rule { get; set; }

		[FieldOffset(4, 8)]
		public string MinFitThresHold { get; set; }

		[FieldOffset(8, 16)]
		public string Setting { get; set; }

		[FieldOffset(12, 24)]
		public List<MatchmakingRuleString> DesiredValues { get; set; }

		[FieldOffset(16, 32)]
		public bool IgnoreIfDefault { get; set; }

		[FieldOffset(17, 33)]
		public bool MergeValues { get; set; }

		public MatchmakingGenericRule()
		{
			DesiredValues = new List<MatchmakingRuleString>();
		}
	}
}
