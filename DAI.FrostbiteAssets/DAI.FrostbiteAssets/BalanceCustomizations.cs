using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BalanceCustomizations : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<LootData> Loot { get; set; }

		[FieldOffset(4, 8)]
		public float MinLevelOverride { get; set; }

		[FieldOffset(8, 12)]
		public float MaxLevelOverride { get; set; }

		[FieldOffset(12, 16)]
		public float RankOverride { get; set; }

		[FieldOffset(16, 24)]
		public List<BWModifiableStatValuePair> StatModifiers { get; set; }

		public BalanceCustomizations()
		{
			StatModifiers = new List<BWModifiableStatValuePair>();
		}
	}
}
