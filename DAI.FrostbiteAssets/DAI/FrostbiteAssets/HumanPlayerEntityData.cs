namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class HumanPlayerEntityData : HumanPlayerProxyEntityData
	{
		[FieldOffset(20, 104)]
		public float PlayerKilledDelay { get; set; }

		[FieldOffset(24, 108)]
		public float PostReviveShortRespawnTime { get; set; }

		[FieldOffset(28, 112)]
		public int MaxReviveCount { get; set; }
	}
}
