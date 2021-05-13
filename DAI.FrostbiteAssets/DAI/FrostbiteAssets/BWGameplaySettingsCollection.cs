using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWGameplaySettingsCollection : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<ExperienceSettings>> GameplaySettings { get; set; }

		public BWGameplaySettingsCollection()
		{
			GameplaySettings = new List<ExternalObject<ExperienceSettings>>();
		}
	}
}
