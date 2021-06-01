using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InquisitionExperienceSettings : ExperienceSettings
	{
		[FieldOffset(36, 104)]
		public List<int> AgentsGained { get; set; }

		[FieldOffset(40, 112)]
		public List<int> PerksGained { get; set; }

		public InquisitionExperienceSettings()
		{
			AgentsGained = new List<int>();
			PerksGained = new List<int>();
		}
	}
}
