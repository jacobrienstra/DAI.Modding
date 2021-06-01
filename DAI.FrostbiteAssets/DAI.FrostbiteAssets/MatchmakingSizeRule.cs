using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingSizeRule : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Setting { get; set; }

		[FieldOffset(4, 8)]
		public List<MatchmakingSizeConfiguration> Configurations { get; set; }

		public MatchmakingSizeRule()
		{
			Configurations = new List<MatchmakingSizeConfiguration>();
		}
	}
}
