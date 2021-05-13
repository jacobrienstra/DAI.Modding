namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OperationOutputData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<WarTableAsset> Operation { get; set; }
	}
}
