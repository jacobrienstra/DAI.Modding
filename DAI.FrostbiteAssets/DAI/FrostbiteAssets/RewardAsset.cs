namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RewardAsset : BaseRewardAsset
	{
		[FieldOffset(12, 80)]
		public ExternalObject<LootDropObject> Loot { get; set; }

		[FieldOffset(16, 88)]
		public uint Experience { get; set; }

		[FieldOffset(20, 92)]
		public uint Power { get; set; }

		[FieldOffset(24, 96)]
		public uint Agents { get; set; }
	}
}
