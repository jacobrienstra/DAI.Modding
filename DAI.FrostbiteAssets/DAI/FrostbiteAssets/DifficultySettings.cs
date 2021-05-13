using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DifficultySettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<DifficultyMode>> Modes { get; set; }

		public DifficultySettings()
		{
			Modes = new List<ExternalObject<DifficultyMode>>();
		}
	}
}
