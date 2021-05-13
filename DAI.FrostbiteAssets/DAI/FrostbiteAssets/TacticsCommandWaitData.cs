namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticsCommandWaitData : TacticsCommandData
	{
		[FieldOffset(16, 96)]
		public float WaitTimeInSeconds { get; set; }
	}
}
