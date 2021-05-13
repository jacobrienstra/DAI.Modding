using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomizedUpgradeAttachment : LinkObject
	{
		[FieldOffset(0, 0)]
		public LootItemProbability UpgradeProbabiltyOverride { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<LootTableObject> LootUpgradeSlot1 { get; set; }

		[FieldOffset(8, 16)]
		public ExternalObject<LootTableObject> LootUpgradeSlot2 { get; set; }
	}
}
