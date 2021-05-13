namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BalanceExtraSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public BalanceCustomizations BalanceOverride { get; set; }
	}
}
