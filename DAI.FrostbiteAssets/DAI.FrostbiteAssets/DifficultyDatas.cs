using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DifficultyDatas : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<GameSettings>> Difficulties { get; set; }

		public DifficultyDatas()
		{
			Difficulties = new List<ExternalObject<GameSettings>>();
		}
	}
}
