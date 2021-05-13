using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootData : BaseLootData
	{
		[FieldOffset(8, 24)]
		public List<ExternalObject<DataContainer>> LootTables { get; set; }

		[FieldOffset(12, 32)]
		public List<ExternalObject<DataContainer>> LootDrops { get; set; }

		public LootData()
		{
			LootTables = new List<ExternalObject<DataContainer>>();
			LootDrops = new List<ExternalObject<DataContainer>>();
		}
	}
}
