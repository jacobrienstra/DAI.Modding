using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPLootGrantLogicEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int LootTableID { get; set; }

		[FieldOffset(20, 104)]
		public List<MPLootPayload> Payload { get; set; }

		[FieldOffset(24, 112)]
		public int Seed { get; set; }

		[FieldOffset(28, 116)]
		public bool UseRandomSeed { get; set; }

		public MPLootGrantLogicEntityData()
		{
			Payload = new List<MPLootPayload>();
		}
	}
}
