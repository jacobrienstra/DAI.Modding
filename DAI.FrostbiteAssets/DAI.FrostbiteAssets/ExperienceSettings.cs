using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ExperienceSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public List<int> ExpToNextLevel { get; set; }

		[FieldOffset(16, 80)]
		public float BarFillTime { get; set; }

		[FieldOffset(20, 84)]
		public float LevelBannerShowTime { get; set; }

		[FieldOffset(24, 88)]
		public float PauseForLevelUpTime { get; set; }

		[FieldOffset(28, 92)]
		public float WaitUntilHideTime { get; set; }

		[FieldOffset(32, 96)]
		public ExternalObject<FloatProvider_If> ExpMultiplier { get; set; }

		public ExperienceSettings()
		{
			ExpToNextLevel = new List<int>();
		}
	}
}
